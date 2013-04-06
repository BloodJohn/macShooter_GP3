/* ПОВЕДЕНИЕ ВРАГА */

using UnityEngine;
using System.Collections;

public class FoeController : MonoBehaviour {
	
	private float Speed;
	private Vector3 StartPosition;
	public GameObject DeadFoePrefab;
	
	// Use this for initialization
	void Start () {
		//Задаём случайную скорость
		Speed = Random.Range( .5f, 2f );
		//Запоминаем положение на старте
		StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Перемещаем врага вперёд, шатая его в бок по синусу, зависимому от общего количества времени в секундах
		transform.Translate( Mathf.Cos( Time.time * 10 ) * 2, 0, Speed );
		
		//Проверяем на удалённость от места создания. Если враг переместился дальше, чем на 300px, то он явно уже за камерой - время умирать
		if ( Vector3.Distance( transform.position, StartPosition ) > 300 )
			Destroy( gameObject );
	}
	
	//Это событие вызывается когда GameObject сталкивается с физическим телом
	void OnCollisionEnter( Collision collision )
	{
		//Мы можем много с кем столкнуться; на всякий случай стоит проверить,
		//относится ли объект, с которым мы столкнулись, к игроку (тэг можно задать в инспекторе)
		if ( collision.collider.gameObject.tag == "Player" )
		{
			//Да! Враг убит!
			
			Statistics.Score++; //Обращаемся к статической переменной класса со статистикой
			Instantiate( DeadFoePrefab ); //Создаём GameObject, отвечающий за смерть врага
			Destroy( collision.collider.gameObject ); //Удаляем врага
			Destroy( gameObject ); //Удаляем шар, которым столкнулись с врагом
		}
		
	}
}
