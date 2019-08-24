using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool _isGameOver;
    public bool IsGameOver { get { return _isGameOver; } }

    public static GameManager Instance { get => instance; }

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
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        LoseScreen.Open();
    }

    public void UpdateScore(int i)
    {

    }
    // end the level


   

}
