using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpingBeanController : MonoBehaviour
{
	private Rigidbody rb;
	private float jumpForce = 10f; 
	
	public int RandomNumber(int min, int max)  
	{
		System.Random random = new System.Random();  
		return random.Next(min, max);  
	} 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RandomNumber(0, 1000) % 100 == 0 && rb.velocity.y == 0) {
			rb.AddForce(new Vector3(0.01f, jumpForce, 0.01f), ForceMode.Impulse);
		}
    }
	
	void OnMouseDown(){
		rb.AddForce(new Vector3(0.01f, jumpForce, 0.01f), ForceMode.Impulse);
	}
}
