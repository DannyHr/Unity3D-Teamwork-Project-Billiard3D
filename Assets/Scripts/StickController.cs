using UnityEngine;
using System.Collections;

public class StickController : MonoBehaviour {

    public Transform playerTransform;
    public float rotationSpeed = 4f;

    private Vector3 rotateAxis;


    void Start () {
        rotateAxis = new Vector3(0f, transform.position.y, 0f);
    }
	

	void Update () {

        if (CameraController.isAutoMode) return;

        float currentRotation = 0.0f;

        if (Input.GetKey(KeyCode.A) )
        {
            currentRotation = rotationSpeed*Time.deltaTime;
        }
        
        if( Input.GetKey(KeyCode.D) )
        {
            currentRotation = -rotationSpeed * Time.deltaTime;
        }

        if ( currentRotation != 0.0f)
        {
            this.transform.RotateAround(playerTransform.position, rotateAxis, currentRotation);
        }
	}
}
