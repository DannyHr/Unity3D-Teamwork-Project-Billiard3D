using System;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public Rigidbody ballBody;
    float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(ballBody.velocity.y) > 0.0f)
        {
            ballBody.velocity = new Vector3(ballBody.velocity.x, 0.001f, ballBody.velocity.z);
        }

        speed = ballBody.velocity.magnitude;
        if (speed < 0.4f)
        {
            ballBody.Sleep();
        }
    }
}
