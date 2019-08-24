using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu<MainMenu>
{
    
    public void OnPlayPressed()
    {
        LevelLoader.LoadNextLevel();
        GameMenu.Open();
    }

    public void OnSettingsPressed()
    {
        SettingsMenu.Open();
    }

    public void OnCreditsPressed()
    {
        CreditsScreen.Open();
    }

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}
