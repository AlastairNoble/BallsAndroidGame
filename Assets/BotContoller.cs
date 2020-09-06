using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BotContoller : MonoBehaviour
{
    private Rigidbody box;
    public Transform center;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform ball;
    public GameControl ending;
    private float height = .7f;
    public float speed;
    private float angle = 0;
    private Vector3 direction;
    private int rand;
    private System.Random rnd = new System.Random();
    public float speedInterval = 3;
    public float moreSpeed = .5f;
    private float timer1;
    private float timer;
    public float numSpeedIncreases = 10;
    private float count;
    public float speedDelay = 10;


    void Start()
    {
    box = GetComponent<Rigidbody>();
        rand = 1;
        timer1 = speedInterval;
        timer = speedDelay;
    }

    void Update()
    {
        roll();
        checkHeight();
        changeSpeed();
        comeBack();
    }
    void comeBack()
    {
        if (box.transform.position.y < 0)
        {
            box.transform.position = new Vector3(box.transform.position.x, 1.5f, box.transform.position.z);
        }
    }
    void changeSpeed()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        
        if(timer < 0)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0 && count<numSpeedIncreases)
            {
                timer1 = speedInterval;
                speed += moreSpeed;
                count++;

            }
        } 
        
    }
    void checkHeight()
    {
        if (box.transform.position.y < 0)
        {
            //box.transform.position.y = 1;
        }
    }

    void roll()
    {
        
        if (angle < 90)
        {
            switch (rand)
            {
                case 1:
                    rollUp();
                    break;
                case 2:
                    rollRight();
                    break;
                case 3:
                    rollDown();
                    break;
                case 4:
                    rollLeft();
                    break;
            }
  
        }
        if (angle >= 90)
        {
            getRandom(); // changes rand value

            angle = 0;
            center.transform.position = box.transform.position;
        }     
    }


    void rollUp()
    {
        box.transform.RotateAround(up.transform.position, Vector3.right, Time.deltaTime * speed);
        angle += Time.deltaTime * speed;
    }
    void rollDown()
    {
        box.transform.RotateAround(down.transform.position, Vector3.left, Time.deltaTime * speed);
        angle += Time.deltaTime * speed;
    }
    void rollLeft()
    {
        box.transform.RotateAround(left.transform.position, Vector3.forward, Time.deltaTime * speed);
        angle += Time.deltaTime * speed;
    }
    void rollRight()
    {
        box.transform.RotateAround(right.transform.position, Vector3.back, Time.deltaTime * speed);
        angle += Time.deltaTime * speed;
    }

    void getRandom() //also checks if at edge & changes accordingly
    {

        if(rnd.Next(1, 6)==1) //one in 5 chance of this
        {
            rand = rnd.Next(1, 5);
        }
        if (box.transform.position.x > 8 && rand==2)
            rand = 4;
        if (box.transform.position.x < -8 && rand == 4)
            rand = 2;
        if (box.transform.position.z > 8 && rand == 1)
            rand = 3;
        if (box.transform.position.z < -8 && rand ==3)
            rand = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == ball)
        {
            ending.isDead = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == ball)
        {
            ending.isDead = false;
        }
    }
}
