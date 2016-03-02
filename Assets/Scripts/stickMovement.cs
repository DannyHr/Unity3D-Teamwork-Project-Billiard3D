using UnityEngine;
using System.Collections;

public class stickMovement : MonoBehaviour {

	private Rigidbody rb;
	public float mouseSensitivity;
	// We will multiply our sphere velocity by this number with each frame, thus dumping it
	public float dampingFactor = 0.98f;
	// After our velocity will reach this threshold, we will simply set it to zero and stop damping
	public float dampingThreshold = 0.1f;

	public float MovementMultiplayer;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

		public Transform target;
		// Update is called once per frame
		void Update () {
			transform.LookAt (target);
		}

	void FixedUpdate() {

		float m_horizontal = Input.GetAxis ("Mouse X") * - 1;
		float m_vertical = Input.GetAxis ("Mouse Y");
		float k_horizontal = Input.GetAxis ("Horizontal");
		float k_vertical = Input.GetAxis ("Vertical");

		print (k_horizontal);

		Vector3 mouseMovement = new Vector3 (0f, m_vertical * mouseSensitivity, m_horizontal * mouseSensitivity);
		Vector3 keyboardMovement = new Vector3 (0f, k_vertical * 2, k_horizontal * 2);
		//rb.rotation(Vector3)
		//if (Input.GetButtonDown("Jump"))
		Quaternion horizontalRotation = Quaternion.Euler(keyboardMovement * Time.deltaTime);

		rb.MoveRotation(rb.rotation * horizontalRotation);
		rb.AddForce(mouseMovement * MovementMultiplayer);
		StartCoroutine(DampVelocity(rb));
		//velocity
	}


//	void OnGUI(){
//		Event e = Event.current;
//		//print (e.mousePosition.x);
//	}

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

}
