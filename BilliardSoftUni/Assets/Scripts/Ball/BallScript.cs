using System;
using UnityEngine;

public class BallScript : MonoBehaviour
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
        if (ballBody.velocity.y > 0.000000001f)
        {
            ballBody.velocity = new Vector3(ballBody.velocity.x, 0f, ballBody.velocity.z);
        }

        speed = ballBody.velocity.magnitude;
        if (speed < 0.4f)
        {
            ballBody.Sleep();
        }
    }
}
