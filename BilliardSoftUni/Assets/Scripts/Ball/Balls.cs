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
		speed = ballBody.velocity.magnitude;
		if (speed < 0.4f)
		{
			ballBody.Sleep();
		}
	}
}
