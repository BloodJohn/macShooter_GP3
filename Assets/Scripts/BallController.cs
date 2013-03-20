using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Hit( Vector3 dir )
	{
		rigidbody.AddForce( dir * -100 );
	}
}
