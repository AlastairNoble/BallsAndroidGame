using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnimies : MonoBehaviour
{
    public GameObject originalCube;
    public GameObject trackerCube;

    public int maxCubes = 10;
    public int maxTrackers = 3;

    private int numCubes = 1;
    private int numTrackers = 1;

    public float CubeInterval = 2;
    public float TrackerInterval = 2;

    private float timer1;
    private float timer2;


    void Start()
    {
        timer1 = CubeInterval;
        timer2 = TrackerInterval;
    }

    void Update()
    {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (timer1 <= 0 && numCubes < maxCubes)
        {
            Instantiate(originalCube);
            timer1 = CubeInterval;
            numCubes++;
        }
        if (timer2 <= 0 && numTrackers < maxTrackers)
        {
            Instantiate(trackerCube);
            timer2 = TrackerInterval;
            numTrackers++;
        }
    }
}
