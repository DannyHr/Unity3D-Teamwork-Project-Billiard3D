using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public static bool isAutoMode = false;

    public GameObject stick;
    public Transform ballTransform;

    private int cameraRotateSpeed;
    private int cameraZoomSpeed;
    private bool isMouseDown;
    private Vector3 rotateAxis;
    private Vector3 rotatePoint;

    // Use this for initialization
    void Start()
    {
        cameraRotateSpeed = 30;
        cameraZoomSpeed = 50;

        rotateAxis = new Vector3(0.0f, 0.5f, 0.0f);
        rotatePoint = new Vector3(0f, 1f, 0f);
    }

    void Update()
    {
        if (isAutoMode)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0)) isMouseDown = true;
        if (Input.GetMouseButtonUp(0)) isMouseDown = false;

        if (isMouseDown)
        {
            transform.RotateAround(rotatePoint, rotateAxis, Input.GetAxis("Mouse X") * cameraRotateSpeed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(Vector3.forward * cameraZoomSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(Vector3.back * cameraZoomSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isAutoMode)
        {
            transform.RotateAround(ballTransform.position, rotateAxis, -.02f);
        }
    }
}
