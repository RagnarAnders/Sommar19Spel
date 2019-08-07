using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highscoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
