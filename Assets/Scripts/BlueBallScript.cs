using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.CompareTag("blue-ball"))
		{
			FindObjectOfType<AudioManager>().Play("clink");
		}
	}
}
