using UnityEngine;
using System.Collections;

public class mainCamera : MonoBehaviour {
	
	private Vector3 offset;
	public GameObject stick;

	// Use this for initialization
	void Start () {
		offset = transform.position - stick.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = stick.transform.position + offset;
	}

}
