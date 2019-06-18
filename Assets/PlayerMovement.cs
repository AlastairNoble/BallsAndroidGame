using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  //  private CharacterController characterController;
    private Rigidbody rigidbody;
    public bool isGrounded;
    public float jumpSpeed;
    private float xSpeed;
    private float ySpeed;
    private Vector3 toMove;
    public float playerSpeed;
    private float height = 1f;
    public float maxSpeed;

    private Touch touch;
    private Vector2 OGTouch;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity *= 5;
    }

    void Update()
    {
        isGroundedMethod();
        move();
    }

    void move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0); // first touch for movment (hold)
            if (touch.phase == TouchPhase.Began) //begin moving
            {
                OGTouch.Set(touch.position.x, touch.position.y); // make on screen origin 
            }

            toMove.Set(touch.position.x - OGTouch.x, 0, touch.position.y - OGTouch.y);

            if (Input.touchCount == 2 && isGrounded) // second touch for jump
            {
                jump();
            }
        }
        else
        {
            toMove.Set(0, 0, 0);
        }

        if (toMove.magnitude > 1)
        {
            toMove.Normalize();
        }

        rigidbody.velocity = new Vector3(toMove.x * playerSpeed, rigidbody.velocity.y, toMove.z * playerSpeed);

    }
    void jump()
    {
        rigidbody.AddExplosionForce(jumpSpeed * 200f, transform.position - new Vector3(0, -height / 2, 0), 1f, 3.0f);
    }

    void isGroundedMethod()
    {
        isGrounded = Physics.Raycast(transform.position, new Vector3(0,-1,0), height / 1.7f);
    }
}
