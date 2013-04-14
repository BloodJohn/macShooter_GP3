/* ПОВЕДЕНИЕ ВРАГА */

using UnityEngine;
using System.Collections;

public class FoeController : MonoBehaviour {
	
	static float minSpeed = 0.5f;
	static float maxSpeed = 1f;
	private float Speed;
	public GameObject DeadFoePrefab;
	public Transform BarPoint;
	private float startTime;
	private int health = 3;
	
	// Use this for initialization
	void Start () {
		//Задаём случайную скорость
		Speed = Random.Range( minSpeed, maxSpeed );
		startTime = Time.time;
		
		if (maxSpeed < minSpeed*2) maxSpeed += 0.01f;
				else minSpeed +=0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.z < BarPoint.position.z)
		{
			//Перемещаем врага вперёд, шатая его в бок по синусу, зависимому от общего количества времени в секундах
			transform.Translate( 0, 0, Speed );
			
			if (transform.position.z >= BarPoint.position.z) 
			{
				Statistics.Queue++;
				
				if (!Statistics.isGameOver && Statistics.Queue>3) Statistics.isGameOver=true;
			}
		}
		else 
		{
			transform.Translate( 0, Mathf.Cos( (Time.time - startTime) * 10 ), 0 );
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
