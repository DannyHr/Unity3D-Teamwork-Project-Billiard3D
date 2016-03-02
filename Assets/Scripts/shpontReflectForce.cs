using UnityEngine;
using System.Collections;

public class shpontReflectForce : MonoBehaviour {
	public float radius = 1.0F;
	public float power = 10.0F;

	
		void Start() {
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody>();
	
				if (rb != null)
					rb.AddExplosionForce(power, explosionPos, radius, 1.0F);
	
			}
		}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.CompareTag("colorBall")){
			//print ("mara");
			//					other.gameObject.SetActive (false);
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody>();

				if (rb != null)
					rb.AddExplosionForce(power, explosionPos, radius, 5.0F);

			}
		}

	}

}
