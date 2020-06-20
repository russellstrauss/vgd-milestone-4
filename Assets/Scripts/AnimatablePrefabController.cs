using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatablePrefabController : MonoBehaviour
{
	
	private Animator animator;
	private Boolean colliding;
	
	void Start() {
		animator = gameObject.GetComponent<Animator>();
	}

	void Update() {
		if (colliding) {
			animator.speed = 1f;
		}
		else {
			animator.speed = 0.25f;
		}
	}
	
	void OnTriggerEnter(Collider c) {
		
		if (c.attachedRigidbody != null) {
			
			AnimatablePrefabCollector collector = c.attachedRigidbody.gameObject.GetComponent<AnimatablePrefabCollector>();
			if (collector != null) {
				colliding = true;
			}
		}
	}
	
	void OnTriggerExit(Collider c) {
		if (c.attachedRigidbody != null) {
			
			AnimatablePrefabCollector collector = c.attachedRigidbody.gameObject.GetComponent<AnimatablePrefabCollector>();
			if (collector != null) {
				colliding = false;
			}
		}
	}
}
