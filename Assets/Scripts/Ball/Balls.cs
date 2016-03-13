using UnityEngine;
using System.Collections;

public class Balls : MonoBehaviour
{

	public static int BALL_FUll_FILL = 0;
	public static int BALL_HALF_FILL = 1;
	public Rigidbody rigidbody;

	void Awake()
	{
		Invoke("HitBall", 1f);  // Calls HitBall in 1 second.
	}
	private void HitBall()
	{
		rigidbody.AddForce(new Vector3(-5f, 0f, 3f), ForceMode.Impulse);
	}
}
