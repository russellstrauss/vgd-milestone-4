using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBall : MonoBehaviour
{
	
	void Start() {
		
	}

	void Update() {
		
	}
	
	void OnTriggerEnter(Collider c) {
		
		if (c.attachedRigidbody != null) {
			
			BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
			if (bc != null) {	
				EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
				Destroy(this.gameObject);
				FindObjectOfType<AudioManager>().Play("bomb");
				bc.ReceiveBall();
			}
		}
	}
}
