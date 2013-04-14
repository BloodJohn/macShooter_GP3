/*ПОВЕДЕНИЕ ГЕНЕРАТОРА ВРАГОВ*/


using UnityEngine;
using System.Collections;

public class FoeGenerator : MonoBehaviour {
	
	public GameObject FoePrefab; //Префаб объекта врага
	public GameObject DeadFoePrefab; //Префаб объекта, отвечающего за поведение при умирании врага
	public Transform[] PointList;
	
	
	// Use this for initialization
	void Start () {
		//Запускаем Coroutine (метод, который имеет возможность приостанавливать своё действите, пока yield не вернёт значение)
		StartCoroutine( "GenerateFoe" );
	}
	
	//Coroutine должен иметь тип IEnumerator
	IEnumerator GenerateFoe()
	{
		Transform current = PointList[Random.Range(0, PointList.Length)];
		
		//Получаем позицию для генерации относительно объекта, который служит точкой, от которой нам стоит отталкиваться при генерации
		Vector3 pos = current.position + Vector3.left * 20 + Vector3.right * Random.Range( 0f, 40f );
		Quaternion rot = current.rotation;
		//Копируем в сцену нового врага из префаба с помощью Instantiate, задаём вычисленную позицию и поворот на 180 градусов
		GameObject newFoe = (GameObject)Instantiate( FoePrefab, pos, rot );
		//Передаём ему ссылку на префаб с поведением при смерти врага
		newFoe.GetComponent<FoeController>().DeadFoePrefab = DeadFoePrefab;
		//yield приостановит выполнение Coroutine, пока WaitForSeconds не подождёт нужное количество секунд (заданное случайно)
		yield return new WaitForSeconds( Random.Range( 0.5f, 1.5f ) );
		//Снова запускаем Coroutine
		StartCoroutine( "GenerateFoe" );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
