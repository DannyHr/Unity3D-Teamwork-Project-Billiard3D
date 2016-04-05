using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class StickController : MonoBehaviour
{
    public Slider forceSlider;
    public GameController GameController;
    public Transform WhiteBallTransform;
    public Rigidbody WhiteBallRigidbody;
    public float RotationSpeed;
    public GameObject stick;
    public GameObject Balls;

    private Vector3 rotateAxis;
    private bool isPressedS;

    void Start()
    {
        isPressedS = false;
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
            this.stick.gameObject.transform.position = new Vector3(currentPos.x - 24.0f, currentPos.y + 2.9f,
                currentPos.z);
            this.stick.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            rotateAxis = new Vector3(0f, this.WhiteBallTransform.position.y, 0f);
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;

            float currentRotation = 0.0f;

            if (!GameController.gamePaused)
            {
                if (Input.GetKeyDown(KeyCode.S) && !isPressedS)
                {
                    isPressedS = true;

                    var force = this.forceSlider.value;

                    var stickPosition = this.stick.transform.position;
                    var ballPosition = this.WhiteBallTransform.position;

                    var forceDirection = ballPosition - stickPosition;

                    var multiplier = 1.0f / (Mathf.Abs(forceDirection.x) + Mathf.Abs(forceDirection.z));
                    var forceX = forceDirection.x * multiplier;
                    var forceZ = forceDirection.z * multiplier;

                    //Debug.Log("ForceX = " + forceX);
                    //Debug.Log("ForceZ = " + forceZ);

                    var forceVector = new Vector3(forceX * force, -0.3f, forceZ * force);
                    StartCoroutine(HitBall(forceVector, 1f));
                }

                if (Input.GetKey(KeyCode.A))
                {
                    currentRotation = this.RotationSpeed * Time.deltaTime;
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    currentRotation = -this.RotationSpeed * Time.deltaTime;
                }

                if (currentRotation != 0.0f)
                {
                    this.stick.transform.RotateAround(this.WhiteBallTransform.position, rotateAxis, currentRotation);
                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    isPressedS = false;
                }
            }
        }
    }

    private IEnumerator HitBall(Vector3 force, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        this.WhiteBallRigidbody.AddForce(force, ForceMode.Impulse);
        //this.WhiteBallTransform.Rotate(Vector3.right, Time.deltaTime * 50.0f, Space.World);
    }
}
