using UnityEngine;

public class WhiteBall : MonoBehaviour
{
	public static int BALL_FUll_FILL = 0;
	public static int BALL_HALF_FILL = 1;
	public Rigidbody ballBody;
	private float speed;

	void Awake()
	{
		Invoke("HitBall", 1f);  // Calls HitBall in 1 second.
	}
	private void HitBall()
	{
		ballBody.AddForce(new Vector3(100f, 0f, -0.3f), ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update()
	{
		speed = ballBody.velocity.magnitude;
		if (speed < 0.4f)
		{
			ballBody.Sleep();
		}
	}
}
