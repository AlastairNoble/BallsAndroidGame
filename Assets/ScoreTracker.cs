using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public ScoreTracker scoreTracker;
    public GameControl gameControl;
    public Text gameOverScore;
    public static float highScore;
    public Text highScoreText;
    public bool deletable = false;

    public int savedScore;

    private void Awake()
    {
        if (!deletable)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("HighScore")>=highScore)
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (gameControl.getScore() >= scoreTracker.getHighScore()) //if gamescore bigger than previous highscore.... >= scoreTracker.
        {
            highScore = gameControl.getScore();
        }
               

        gameOverScore.text = "Score: " + gameControl.getScore();
        highScoreText.text = "High Score: " + highScore;

        PlayerPrefs.SetInt("HighScore", (int)highScore);
    }

    void Update()
    {
        
    }
    public float getHighScore()
    {
        deletable = true;
        return highScore;
    }
}
