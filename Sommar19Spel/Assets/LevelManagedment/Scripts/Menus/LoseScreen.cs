using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : Menu<LoseScreen>
{
    public void OnRestartPressed()
    {
        base.OnBackPressed();
        Time.timeScale = 1;
        LevelLoader.ReloadLevel();
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1;
        LevelLoader.LoadMainMenuLevel();
        MainMenu.Open();
    }

}
