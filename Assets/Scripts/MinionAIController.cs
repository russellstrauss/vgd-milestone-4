using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIController : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject[] waypoints;
	public GameObject[] movingWaypoints;
	private int currentWaypoint = 0;
	private int currentMovingWaypoint = 0;
	Animator animator;
	
	public AIState aiState;
	public enum AIState {
		Patrol,
		GoToMovingWaypoint
	};
	
	void Start() {
		animator = gameObject.GetComponent<Animator>();
		aiState = AIState.GoToMovingWaypoint;
		
		if (aiState == AIState.Patrol) setNextStaticWaypoint();
		//else if (aiState == AIState.GoToMovingWaypoint) setNextMovingWaypoint();
	}

	void Update() {
		
		switch (aiState) {
			case AIState.Patrol:
				animator.SetFloat("vely", agent.velocity.magnitude / agent.speed);
				if ((agent.remainingDistance - agent.stoppingDistance < 2) && !agent.pathPending) setNextStaticWaypoint();
			break;
			case AIState.GoToMovingWaypoint:
				animator.SetFloat("vely", agent.velocity.magnitude / agent.speed);
				if ((agent.remainingDistance < 1) && !agent.pathPending) {
					setNextMovingWaypoint();
				}
			break;
			default:
			break;
		}
	}
	
	void setNextStaticWaypoint() {
		if (currentWaypoint > waypoints.Length - 1) currentWaypoint = 0;
		Vector3 destination = waypoints[currentWaypoint].transform.position;
		setDestination(destination);
		currentWaypoint++;
		aiState = AIState.GoToMovingWaypoint;
	}
	
	void setNextMovingWaypoint() {
		if (currentMovingWaypoint > movingWaypoints.Length - 1) {
			currentMovingWaypoint = 0;
		}
		Vector3 destination = movingWaypoints[currentMovingWaypoint].transform.position;
		float distance = (destination - agent.transform.position).magnitude;
		float lookAheadPosition = distance / agent.speed;
		Rigidbody rb = movingWaypoints[currentMovingWaypoint].GetComponent<Rigidbody>();
		Vector3 futureDestination = destination + lookAheadPosition * rb.velocity;
		setDestination(destination);
		currentMovingWaypoint++;
		aiState = AIState.Patrol;
	}
	
	void setDestination(Vector3 destination) {
		agent.SetDestination(destination);
	}
}
