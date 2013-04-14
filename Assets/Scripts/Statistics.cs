/* КЛАСС, ОТОБРАЖАЮЩИЙ И ПРИНИМАЮЩИЙ СТАТИСТИКУ */

using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {
	
	//Статическая переменная, которая содержит количество очков
	public static int Score = 0;
	public static int Queue = 0;
	public static bool isGameOver = false;
	
	//ВНИМАНИЕ! Для реализации статических переменных стоит убедиться, что данное поведение будет существовать на сцене в единственном экземпляре
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update()
	{
		if ( Input.GetMouseButtonDown( 0 ) && isGameOver )
			RestartGame();
	}
	
	// OnGUI вызывается в то время, когда необходимо прорисоват стандартное GUI Unity
	void OnGUI () {
		
		if (isGameOver)
		{
			GUI.Label( new Rect( Screen.width/2 - 100, Screen.height/2 - 100, 300, 240 ), "Game Over!" );
			GUI.Label( new Rect( Screen.width/2 - 100, Screen.height/2 - 140, 300, 280 ), "Score: " + Score.ToString() );
		}
		else
		{
		//Вывод надписи с количеством очков
		GUI.Label( new Rect( 0, 0, 100, 20 ), "Score: " + Score.ToString() );
		GUI.Label( new Rect( 0, 20, 100, 40 ), "Queue: " + Queue.ToString() );
		}
	}
	
	public static void RestartGame()
	{
		Score = 0;
		Queue = 0;
		isGameOver = false;
		Application.LoadLevel( "main" );
	}
}
