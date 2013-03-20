using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			Ray fireRay = camera.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			Physics.Raycast( fireRay, out hit );
			if ( (hit.collider != null ) && (hit.collider.gameObject.layer == 8) )
				hit.collider.gameObject.GetComponent<BallController>().Hit( hit.normal );
		}
	}
}
