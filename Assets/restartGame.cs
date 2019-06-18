using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public bool hello = false;
    public void restart()
    {
        hello = true;
        SceneManager.LoadScene("GameScene");
    }
}
