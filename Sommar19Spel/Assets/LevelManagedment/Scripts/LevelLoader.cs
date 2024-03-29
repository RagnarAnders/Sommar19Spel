﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static int mainMenuIndex = 1;

    public static void LoadLevel(string levelName)
    {
        if (Application.CanStreamedLevelBeLoaded(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
        }
    }

    public static void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (levelIndex == mainMenuIndex)
            {
                MainMenu.Open();
            }
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
        }
    }

    public static void ReloadLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex); 
    }

    public static void LoadNextLevel()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) %
            SceneManager.sceneCountInBuildSettings;
        nextSceneIndex = Mathf.Clamp(nextSceneIndex, mainMenuIndex, nextSceneIndex);
        LoadLevel(nextSceneIndex);
    }

    public static void LoadMainMenuLevel()
    {
        LoadLevel(mainMenuIndex);
    }
}
