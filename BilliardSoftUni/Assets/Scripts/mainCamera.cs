using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public GameObject Stick;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Stick.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Stick.transform.position + offset;
    }
}
