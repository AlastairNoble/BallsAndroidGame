using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float lives = 5;
    public bool isDead;
    public static float score;
    private float timer;
    private float timer1;
    public float scoreInterval = 1;
    private float multiplyer = 1;
    public float multiplyerInterval = 10;
    public Text scoreText;
    public Text livesText;
    public bool gameOn;
    private bool deletable = false;

    public float getScore()
    {
        deletable = true;
        return score;
    }
    void Start()
    {
        isDead = false;
        timer = scoreInterval;
        timer1 = multiplyerInterval;
        gameOn = true;
        score = 0;
    }
    private void Awake()
    {
        if (deletable)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        respawn();
        scoreSystem();
        displayScore();
    }

    void displayScore()
    {
        scoreText.text = score.ToString();
        livesText.text = " ";

        for (float i = 0; i < lives; i++){
            livesText.text += "* ";
        }
    }
    void scoreSystem()
    {
        if (gameOn)
        {
            timer -= Time.deltaTime;
            timer1 -= Time.deltaTime;
            if (timer <= 0)
            {
                score += 1 * multiplyer;
                timer = scoreInterval;
            }
            if (timer1 <= 0)
            {
                multiplyer *= 2;
                timer1 = multiplyerInterval;
            }
    }

}
    void respawn()
    {
        if (rigidbody)
        {
            if ((rigidbody.transform.position.y < -3f || isDead) && lives>=0)
            {
                rigidbody.velocity = new Vector3(0, .1f, 0);
                rigidbody.transform.position = new Vector3(0, 6f, 0);
                lives--;
                isDead = false;
            }
            if (lives < 0)
            {
                gameOn = false;
                SceneManager.LoadScene("EndScene");
            }
        }
        
    }
}
