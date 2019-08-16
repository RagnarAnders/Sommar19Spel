using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text text;
    private int score;
    private int PlayerLives;

    public static GameController Instance { get; private set; }
    
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        Instance = this;
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void UpdateGameState()
    {
        PlayerLives--;
        if(PlayerLives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        HandleHighscore();
        SceneManager.LoadScene(0);
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    private void HandleHighscore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            if(score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        if (text != null)
        {
            text.text = "Score: " + score.ToString();
        }
    }
}
