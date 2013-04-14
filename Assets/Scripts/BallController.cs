/* ПОВЕДЕНИЕ ШАРА, УБИВАЮЩЕГО ВРАГОВ */
using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	public Transform WallPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.y < WallPoint.position.y ) //Проверяем, не упал ли шар (плейн с землёй находится в нуле)
			Destroy( gameObject );	//Если да - удаляем
	}
	
}
