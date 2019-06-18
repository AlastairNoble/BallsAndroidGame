using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TrackerBotController : MonoBehaviour
{
    private Rigidbody box;
    public Transform center;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform ball;
    public GameControl ending;
    public float speed;
    private float angle = 0;
    private Vector3 direction;
    public float speedInterval = 3;
    public float moreSpeed = .5f;
    private float timer1;
    private float timer;
    public float numSpeedIncreases = 10;
    private float count;
    public float speedDelay = 10;
    private int rollDirection;
    private float xDifference;
    private float zDifference;
    private float ballAngle;// angle between ball and tracker boi

    void Start()
    {
        box = GetComponent<Rigidbody>();
        rollDirection = 1;
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

        if (timer < 0)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0 && count < numSpeedIncreases)
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
            switch (rollDirection)
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
            getRollDirection(); // changes rand value

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

    void getRollDirection() //also checks if at edge & changes accordingly
    {

        xDifference = ball.position.x - box.position.x;
        zDifference = ball.position.z - box.position.z;

        ballAngle = Mathf.Atan(xDifference / zDifference);

        if(Mathf.Abs(ballAngle) > Mathf.PI / 4)
        {
            if (xDifference > 0)
            {
                rollDirection = 2;
            } else
            {
                rollDirection = 4;
            }
        } else
        {
            if (zDifference > 0)
            {
                rollDirection = 1;
            } else 
            {
                rollDirection = 3;
            }
        }
        
        checkIfAtEdge();
    }

    void checkIfAtEdge()
    {
        // if at the edge V
        if (box.transform.position.x > 9 && rollDirection == 2)
            rollDirection = 4;
        if (box.transform.position.x < -9 && rollDirection == 4)
            rollDirection = 2;
        if (box.transform.position.z > 9 && rollDirection == 1)
            rollDirection = 3;
        if (box.transform.position.z < -9 && rollDirection == 3)
            rollDirection = 1;
        //
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
