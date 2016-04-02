using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StickController : MonoBehaviour
{
    public const float Force = 90.0f;

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
            if (Balls.transform.GetChild(i).gameObject.activeSelf)
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

            var stickPosition = this.stick.transform.position;
            var ballPosition = this.WhiteBallTransform.position;

            var force = ballPosition - stickPosition;

            var multiplier = 1.0f / (Mathf.Abs(force.x) + Mathf.Abs(force.z));
            var forceX = force.x * multiplier;
            var forceZ = force.z * multiplier;

            Debug.Log("ForceX = " + forceX);
            Debug.Log("ForceZ = " + forceZ);

            var forceVector = new Vector3(forceX * Force, -0.3f, forceZ * Force);
            StartCoroutine(HitBall(forceVector, 1f));
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

        this.WhiteBallRigidbody.AddForce(force, ForceMode.Impulse);
    }
}
