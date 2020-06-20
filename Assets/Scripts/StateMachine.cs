using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public AIState aiState;
	public enum AIState
	{
		Patrol,
		GoToAmmoDepot,
		AttackPlayerWithProjectile,
		InterceptPlayer,
		AttackPlayerWithMelee,
		ChasePlayer
		//TODO more? states…
	};
	
	void Start () {
		aiState = AIState.Patrol;
	}
	
	void Update () {
		//state transitions that can happen from any state might happen here
		//such as:
		//if(inView(enemy) && (ammoCount == 0) &&
		// closeEnoughForMeleeAttack(enemy))
		// aiState = AIState.AttackPlayerWithMelee;
		//Assess the current state, possibly deciding to change to a different state
		switch (aiState) {
			case AIState.Patrol:
				//if(ammoCount == 0)
				// aiState = AIState.GoToAmmoDepot;
				//else
				// SteerTo(nextWaypoint);
			break;
			case AIState.GoToAmmoDepot:
				//SteerToClosestAmmoDepot()
			break;
			//... TODO handle other states
			default:
			break;
		}
	}
}