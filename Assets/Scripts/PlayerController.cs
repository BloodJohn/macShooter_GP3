/* ПОВЕДЕНИЕ КАМЕРЫ ИГРОКА */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject BasketBall;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Ждём состояния, при котором левая конпка мыши была только что нажата
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			//Получаем позицию из которой будем запускать мяч через ScreenToWorldPoint
			//Это означает, что мы указываем x и y нашего экрана, а так же отдаление от камеры, и получаем эти координаты в трёхмерном пространстве
			Vector3 position = camera.ScreenToWorldPoint( Input.mousePosition + Vector3.forward * 30 );
			//Создаём шар методом Instantiate, этот метод превратит префаб в GameObject и сразу поместит его на сцену.
			GameObject newBall //Запоминаем в переменной newBall
				= (GameObject)Instantiate( BasketBall, 
				position, Random.rotationUniform ); //Создаём в заранее вычисленном нами положении и задаём ему случайное вращение
			//Обращаемся к его физическому телу и задаём ему определённое ускорение
			newBall.rigidbody.AddForce( Vector3.forward * 3000, ForceMode.Acceleration );
		}
	}
}
