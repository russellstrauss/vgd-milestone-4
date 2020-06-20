using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReporter : MonoBehaviour {
	
	private Vector3 prevPos;
	public float smoothingTimeFactor = 0.5f;
	private Vector3 smoothingParamVel;
	public Vector3 rawVelocity
	{
		get;
		private set;
	}
	
	public Vector3 velocity
	{
		get;
		private set;
	}
	
	
	void Start () {
		prevPos = this.transform.position;
	}
	
	void Update () {
		rawVelocity = (this.transform.position - prevPos) / Time.deltaTime;
		velocity = Vector3.SmoothDamp(velocity, rawVelocity, ref smoothingParamVel, smoothingTimeFactor);
		prevPos = this.transform.position;
	}
}