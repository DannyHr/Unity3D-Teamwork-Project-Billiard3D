using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PocketScript : MonoBehaviour
{
    public GameController gameController;
    private static readonly Vector3 DefaultWhiteBallPosition = new Vector3(-14, 1, 0);

    void OnTriggerEnter(Collider pottedBall)
    {
        gameController.pottedBalls.Enqueue(pottedBall.tag);

        if (pottedBall.tag == "blackBall")
        {
            pottedBall.gameObject.SetActive(false);
        }

        if (pottedBall.tag == "whiteBall")
        {
            pottedBall.GetComponent<Rigidbody>().Sleep();
            pottedBall.transform.position = DefaultWhiteBallPosition;

            Debug.Log("Potted white ball!");
        }

        if (pottedBall.tag == "stripeBall")
        {
            pottedBall.gameObject.SetActive(false);
            Debug.Log("Potted stripe ball!");
        }

        if (pottedBall.tag == "solidBall")
        {
            pottedBall.gameObject.SetActive(false);
            Debug.Log("Potted solid ball!");
        }
    }
}
