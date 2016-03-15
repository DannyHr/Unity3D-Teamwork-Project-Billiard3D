using UnityEngine;
using System.Collections;

public class SetBallInactive : MonoBehaviour {

	void OnTriggerEnter ( Collider other)
    {       

        if ( other.gameObject.CompareTag("colorBalls") )
        {

            other.gameObject.SetActive(false);
            //UIPlayers.instance.SelectBall(); Pass the ball number;

        }
    }
}
