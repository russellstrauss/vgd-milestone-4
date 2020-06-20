using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIController : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	Animator animator;
	
	public AIState aiState;
	public enum AIState {
		Patrol,
		GoToMovingWaypoint
	};
	
	void Start() {
		animator = gameObject.GetComponent<Animator>();
		//aiState = AIState.GoToMovingWaypoint;
		
		if (aiState == AIState.Patrol) setNextWaypoint();
	}

	void Update() {
		
		switch (aiState) {
			case AIState.Patrol:
				animator.SetFloat("vely", agent.velocity.magnitude / agent.speed);
				if (agent.remainingDistance < 2 && !agent.pathPending) setNextWaypoint();
			break;
			case AIState.GoToMovingWaypoint:
				Debug.Log("MovingWaypoint State");
			break;
			default:
			break;
		}
	}
	
	void setNextWaypoint() {
		if (currentWaypoint > waypoints.Length - 1) currentWaypoint = 0;
		setDestination();
		currentWaypoint++;
	}
	
	void setDestination() {
		Vector3 destination = waypoints[currentWaypoint].transform.position;
		agent.SetDestination(destination);
	}
}
