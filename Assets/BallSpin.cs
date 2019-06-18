using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float spinSpeed = 2;
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = new Vector3(0,spinSpeed,0);
    }


}
