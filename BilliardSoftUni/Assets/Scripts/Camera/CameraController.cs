using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public static bool isAutoMode = false;

    public GameObject stick;
    public Transform ballTransform;

    private int cameraRotateSpeed = 30;
    private int cameraZoomSpeed = 4;
    private bool isMouseDown;
    private Vector3 rotateAxis;
    private Vector3 startPosition;
    private int minDistance = 10;
    private int maxDistance = 30;
    private int currentDistance;

    // Use this for initialization
    void Start()
    {
        rotateAxis = new Vector3(0f, transform.position.y, 0f);
        startPosition = transform.position;
        currentDistance = maxDistance;
    }


    void Update()
    {
        if (isAutoMode) return;
        
        rotateAxis = new Vector3(0f, this.ballTransform.position.y, 0f);

        if (Input.GetMouseButtonDown(0)) isMouseDown = true;
        if (Input.GetMouseButtonUp(0)) isMouseDown = false;

        if (isMouseDown)
        {
            transform.RotateAround(ballTransform.position, rotateAxis, Input.GetAxis("Mouse X") * cameraRotateSpeed);


            float mouseY = Input.GetAxis("Mouse Y");

            if (mouseY != 0.0f)
            {
                float value = mouseY;
                transform.Translate(Vector3.forward * cameraZoomSpeed * Time.deltaTime * value);
            }
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
