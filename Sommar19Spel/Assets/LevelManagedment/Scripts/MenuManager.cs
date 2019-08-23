﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MenuManager : MonoBehaviour
{
    public MainMenu mainMenuPrefab;
    public SettingsMenu settingsMenuPrefab;
    public CreditsScreen creditsScreenPrefab;

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

        Menu[] menuPrefabs = { mainMenuPrefab, settingsMenuPrefab, creditsScreenPrefab };

        foreach (Menu prefab in menuPrefabs)
        {
            if (prefab != null)
            {
                Menu menuInstance = Instantiate(prefab, menuParent);
                if (prefab != mainMenuPrefab)
                {
                    menuInstance.gameObject.SetActive(false);
                }
                else
                {
                    OpenMenu(menuInstance);
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

