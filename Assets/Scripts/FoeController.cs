/* ПОВЕДЕНИЕ ВРАГА */

using UnityEngine;
using System.Collections;

public class FoeController : MonoBehaviour {
	
	private float Speed;
	public GameObject DeadFoePrefab;
	public Transform BarPoint;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		//Задаём случайную скорость
		Speed = Random.Range( .5f, 2f );
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.z < BarPoint.position.z)
		{
			//Перемещаем врага вперёд, шатая его в бок по синусу, зависимому от общего количества времени в секундах
			transform.Translate( Mathf.Cos( (Time.time - startTime) * 10 ) * 4, 0, Speed );
			
			if (transform.position.z >= BarPoint.position.z) Statistics.Queue++;
		}
		else 
		{
			transform.Translate( 0, Mathf.Cos( (Time.time - startTime) * 10 ) * 2, 0 );
		}
		
		//Проверяем на удалённость от места создания. Если враг переместился дальше, чем на 300px, то он явно уже за камерой - время умирать
		//if ( transform.position.z > BarPoint.position.z ) Destroy( gameObject );
	}
	
	//Это событие вызывается когда GameObject сталкивается с физическим телом
	void OnCollisionEnter( Collision collision )
	{
		//Мы можем много с кем столкнуться; на всякий случай стоит проверить,
		//относится ли объект, с которым мы столкнулись, к игроку (тэг можно задать в инспекторе)
		if ( collision.collider.gameObject.tag == "Player" )
		{
			//Да! Враг убит!
			if (transform.position.z >= BarPoint.position.z) Statistics.Queue--;
			Statistics.Score++; //Обращаемся к статической переменной класса со статистикой
			Instantiate( DeadFoePrefab ); //Создаём GameObject, отвечающий за смерть врага
			Destroy( collision.collider.gameObject ); //Удаляем врага
			Destroy( gameObject ); //Удаляем шар, которым столкнулись с врагом
		}
		
	}
}
