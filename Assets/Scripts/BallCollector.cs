using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
	public Boolean hasBall = false;
	
	void Start()
	{
		
	}

	void Update()
	{
		
	}
	
	public void ReceiveBall() {
		hasBall = true;
	}
}
