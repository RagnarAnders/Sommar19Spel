using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool _isGameOver;
    public bool IsGameOver { get { return _isGameOver; } }

    public static GameManager Instance { get => instance; }

    [SerializeField]
    private string nextLevelName;

    [SerializeField]
    private int nextLevelIndex;

    private static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

    // end the level
    public void EndLevel()
    {
        

        // check if we have set IsGameOver to true, only run this logic once
        if (!_isGameOver)
        {
            _isGameOver = true;

            LoadNextLevel();

        }
    }

    public void LoadLevel(string levelName)
    {
        if (Application.CanStreamedLevelBeLoaded(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
        }
    }

    public void ReloadLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {

        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) %
            SceneManager.sceneCountInBuildSettings;

        LoadLevel(nextSceneIndex);

    }

}
