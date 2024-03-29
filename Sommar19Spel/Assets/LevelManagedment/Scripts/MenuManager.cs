﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainMenuPrefab;
    [SerializeField]
    private SettingsMenu settingsMenuPrefab;
    [SerializeField]
    private CreditsScreen creditsScreenPrefab;
    [SerializeField]
    private GameMenu gameMenuPrefab;
    [SerializeField]
    private PauseMenu pauseMenuPrefab;
    [SerializeField]
    private LoseScreen loseScreenPrefab;

    [SerializeField]
    private Transform menuParent;

    private Stack<Menu> menuStack = new Stack<Menu>();

    private static MenuManager instance;

    public static MenuManager Instance { get => instance; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            InitializeMenus();
            Object.DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

    private void InitializeMenus()
    {
        if (menuParent == null)
        {
            GameObject menuParentObject = new GameObject("Menus");
            menuParent = menuParentObject.transform;
        }
        Object.DontDestroyOnLoad(menuParent.gameObject);


        BindingFlags myFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        FieldInfo[] fields = this.GetType().GetFields(myFlags);

        foreach (FieldInfo field in fields)
        {
            Menu prefab = field.GetValue(this) as Menu; 
            if (prefab != null)
            {
                Menu menuInstance = Instantiate(prefab, menuParent);
                //Startar från game scene
                if(SceneManager.GetActiveScene().buildIndex != 1)
                {
                    if(prefab != gameMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(gameMenuPrefab);
                    }
                }
                else
                {
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else if (SceneManager.GetActiveScene().buildIndex != 0)
                    {
                        OpenMenu(menuInstance);
                    }
                }
        
            }
        }
    }

    public void OpenMenu(Menu menuInstance)
    {
        if(menuInstance == null)
        {
            Debug.LogWarning("MENUMANAGER OpenMenu ERROR: invalid menu");
            return;
        }

        if(menuStack.Count > 0)
        {
            foreach(Menu menu in menuStack)
            {
                menu.gameObject.SetActive(false);
            }
        }

        menuInstance.gameObject.SetActive(true);
        menuStack.Push(menuInstance);
    }

    public void CloseMenu()
    {
        if(menuStack.Count == 0)
        {
            Debug.LogWarning("MENUMANAGER CloseMenu ERROR: No menus in stack!");
            return;
        }

        Menu topMenu = menuStack.Pop();
        topMenu.gameObject.SetActive(false);

        if(menuStack.Count > 0)
        {
            Menu nextMenu = menuStack.Peek();
            nextMenu.gameObject.SetActive(true);
        }
    }
}

