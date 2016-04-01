using System.Collections;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    public static int BALL_FUll_FILL = 0;
    public static int BALL_HALF_FILL = 1;
    public Rigidbody ballBody;
    private float speed;

    void Awake()
    {

    }

    private IEnumerator HitBall(Vector3 force, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //ballBody.AddForce(new Vector3(100f, 0f, -0.3f), ForceMode.Impulse);
        ballBody.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            var force = new Vector3(100f, 0f, -0.3f);
            StartCoroutine(HitBall(force, 1f));

            //Invoke("HitBall", 1f);  // Calls HitBall in 1 second.
        }

        speed = ballBody.velocity.magnitude;
        if (speed < 0.4f)
        {
            ballBody.Sleep();
        }
    }
}
