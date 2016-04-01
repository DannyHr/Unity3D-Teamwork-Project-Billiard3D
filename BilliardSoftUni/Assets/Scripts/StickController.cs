using UnityEngine;
using System.Collections;
using System.Linq;

public class StickController : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 4f;
    public GameObject stick;

    private Vector3 rotateAxis;

    void Start()
    {
    }

    void Update()
    {
        if (CameraController.isAutoMode)
        {
            return;
        }

        var allBalls = GameObject.FindGameObjectsWithTag("balls");

        if (allBalls.Any(a => a.GetComponent<Rigidbody>().velocity != Vector3.zero))
        {
            this.GetComponent<MeshRenderer>().enabled = false;

            var currentPos = allBalls[0].GetComponent<Transform>().position;
            this.stick.gameObject.transform.position = new Vector3(currentPos.x - 24.0f, currentPos.y + 2.9f, currentPos.z);

            rotateAxis = new Vector3(0f, playerTransform.position.y, 0f);
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }

        float currentRotation = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            currentRotation = rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentRotation = -rotationSpeed * Time.deltaTime;
        }

        if (currentRotation != 0.0f)
        {
            this.stick.transform.RotateAround(playerTransform.position, rotateAxis, currentRotation);
        }
    }
}
