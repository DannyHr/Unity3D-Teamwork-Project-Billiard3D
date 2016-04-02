using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StickController : MonoBehaviour
{
    public Transform WhiteBallTransform;
    public Rigidbody WhiteBallRigidbody;
    public float RotationSpeed;
    public GameObject stick;
    public GameObject Balls;

    private Vector3 rotateAxis;
    private bool isPressedS = false;

    void Start()
    {
    }

    void Update()
    {
        if (CameraController.isAutoMode)
        {
            return;
        }

        var allBalls = new List<GameObject>();
        for (int i = 0; i < Balls.transform.childCount; i++)
        {
            if (Balls.transform.GetChild(i).GetComponent<MeshRenderer>().enabled)
            {
                allBalls.Add(Balls.transform.GetChild(i).gameObject);
            }
        }

        if (allBalls.Any(a => a.GetComponent<Rigidbody>().velocity != Vector3.zero))
        {
            this.GetComponent<MeshRenderer>().enabled = false;

            var currentPos = allBalls[0].GetComponent<Transform>().position;
            this.stick.gameObject.transform.position = new Vector3(currentPos.x - 24.0f, currentPos.y + 2.9f, currentPos.z);

            rotateAxis = new Vector3(0f, this.WhiteBallTransform.position.y, 0f);
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }

        float currentRotation = 0.0f;

        if (Input.GetKeyDown(KeyCode.S) && !isPressedS)
        {
            isPressedS = true;

            Debug.Log("Pressed S");

            var stickForce = new Vector3(90f, 0f, -0.3f);
            StartCoroutine(HitBall(stickForce, 1f));
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            isPressedS = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentRotation = this.RotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentRotation = -this.RotationSpeed * Time.deltaTime;
        }

        if (currentRotation != 0.0f)
        {
            this.stick.transform.RotateAround(this.WhiteBallTransform.position, rotateAxis, currentRotation);
        }
    }

    private IEnumerator HitBall(Vector3 force, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //ballBody.AddForce(new Vector3(100f, 0f, -0.3f), ForceMode.Impulse);
        this.WhiteBallRigidbody.AddForce(force, ForceMode.Impulse);
    }
}
