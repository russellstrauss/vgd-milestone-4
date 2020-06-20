using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIController : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	
	void Start() {
		setNextWaypoint();
	}

	void Update() {
		Debug.Log(agent.remainingDistance);
		if (agent.remainingDistance < 1) setNextWaypoint();
	}
	
	void setNextWaypoint() {
		if (currentWaypoint > waypoints.Length - 1) currentWaypoint = 0;
		// Debug.Log(waypoints[currentWaypoint]);
		setDestination();
		currentWaypoint++;
	}
	
	void setDestination() {
		Vector3 destination = waypoints[currentWaypoint].transform.position;
		agent.SetDestination(destination);
	}
}
