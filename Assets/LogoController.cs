using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviour
{
    public Light mainLight;
    public float lightIncrease;
    public int stage;
    private float timer;
    public float logoPeriod;
    void Start()
    {
        mainLight.intensity = 0;
        stage = 0;
        timer = logoPeriod;
    }

    void Update()
    {
        switch (stage)
        {
            case 0:
                {
                    if (mainLight.intensity < 1.1)
                    {
                        mainLight.intensity += lightIncrease/100;
                    }else
                    {
                        stage++;
                    }
                    break;
                }
            case 1:
                {
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        stage++;
                    }
                    break;
                }
            case 2:
                {
                    if (mainLight.intensity > 0)
                    {
                        mainLight.intensity -= lightIncrease / 100;
                    } else
                    {
                        SceneManager.LoadScene("StartScene");
                    }
                    break;
                }

                
        }
        
    }
}
