using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceForward : MonoBehaviour
{

	public float thrust;
	public GameObject ThingToForceForward;
	public bool debugTrue = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player") || debugTrue)
		{
			//ThingToForceForward.transform.forward;
		}
	}
}
