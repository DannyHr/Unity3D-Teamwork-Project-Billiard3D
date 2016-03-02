using UnityEngine;
using System.Collections;

public class borderReflectForce : MonoBehaviour
{

	//private float oppositeForce;
	Rigidbody myRigidbody;
	// We will multiply our sphere velocity by this number with each frame, thus dumping it
	public float dampingFactor = 0.98f;
	// After our velocity will reach this threshold, we will simply set it to zero and stop damping
	public float dampingThreshold = 0.1f;
	Vector3 oldVel;
	//private int counter = 0;
	//public float bumperForce = 0.1f;
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		oldVel = myRigidbody.velocity;
		//currentVelocity = rigidbody.velocity;
	
	}


	void OnCollisionEnter (Collision c)
	{
		
		if (c.gameObject.CompareTag ("colorBalls")) {
			ContactPoint cp = c.contacts[0];
			//myRigidbody.velocity = oldVel + cp.normal * oldVel.magnitude;
			//myRigidbody.velocity = Vector3.Reflect(oldVel,cp.normal);

			StartCoroutine(DampVelocity(c.rigidbody));
	 		myRigidbody.velocity += cp.normal*2.0f;
			//print(myRigidbody.velocity);
		}
}

	IEnumerator DampVelocity(Rigidbody target)
	{
		// Disable gravity for the sphere, so it will no longer be accelerated towards the earth, but will retain it's momentum
		target.useGravity = false;

		do
		{
			// Here we are damping (simply multiplying) velocity of the sphere whith each frame, until it reaches our threshold 
			target.velocity *= dampingFactor;
			yield return new WaitForEndOfFrame();
		} while (target.velocity.magnitude > dampingThreshold);

		// Completely stop sphere's momentum
		target.velocity = Vector3.zero;
	}


	//	void OnTriggerEnter(Collider other) {
	//
	//		if(other.gameObject.CompareTag("colorBalls")){
	//			print ("mara");
	//		}
	//
	//	}
}
