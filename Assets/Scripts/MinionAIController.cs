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
	
	void Start() {
		animator = gameObject.GetComponent<Animator>();
		setNextWaypoint();
	}

	void Update() {
		animator.SetFloat("vely", agent.velocity.magnitude / agent.speed);
		if (agent.remainingDistance < 1 && !agent.pathPending) setNextWaypoint();
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
