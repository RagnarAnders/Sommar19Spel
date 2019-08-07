using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public int Score { get; set; }

    private int PlayerLives;

    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        instance = this;
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
        Score = HighScore.HighscoreReference.score;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            if(Score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
    }
}
