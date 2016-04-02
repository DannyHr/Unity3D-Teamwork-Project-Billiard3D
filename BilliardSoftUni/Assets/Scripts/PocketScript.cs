using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PocketScript : MonoBehaviour
{
    public static readonly Vector3 DefaultWhiteBallPosition = new Vector3(-14, 1, 0);

    void OnTriggerEnter(Collider pottedBall)
    {
        if (pottedBall.tag == "blackBall")
        {
            pottedBall.gameObject.SetActive(false);

            //TODO
            Debug.Log("Game Over!");
        }

        if (pottedBall.tag == "whiteBall")
        {
            pottedBall.GetComponent<Rigidbody>().Sleep();
            pottedBall.transform.position = DefaultWhiteBallPosition;
            //TODO Change turn

            Debug.Log("Potted white ball!");
        }

        if (pottedBall.tag == "stripeBall")
        {
            pottedBall.gameObject.SetActive(false);
            Debug.Log("Potted stripe ball!");

            //TODO
        }

        if (pottedBall.tag == "solidBall")
        {
            pottedBall.gameObject.SetActive(false);
            Debug.Log("Potted solid ball!");

            //TODO
        }
    }
}
