using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter ( Collider other)
    {       

        if ( other.gameObject.CompareTag("colorBalls") )
        {

            Destroy(other.gameObject);
            //UIPlayers.instance.SelectBall(); Pass the ball number;

        }
    }
}
