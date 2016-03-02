using UnityEngine;
using System.Collections;

public class whiteForce : MonoBehaviour {

	private Rigidbody rb;

	public float MovementMultiplayer;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontal, 0f, vertical);

		//if (Input.GetButtonDown("Jump"))
		rb.AddForce(movement * MovementMultiplayer);
		//velocity
	}
}