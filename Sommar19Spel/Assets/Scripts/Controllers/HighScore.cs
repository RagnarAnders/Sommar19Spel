using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    Text text;
    public int score;
    public static HighScore HighscoreReference { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        if(HighscoreReference == null)
        {
            HighscoreReference = this;
        }
        score = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        if(text != null)
        {
            text.text = "Score: " + score.ToString();

        }
    }
}
