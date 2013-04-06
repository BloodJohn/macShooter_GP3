/* КЛАСС, ОТОБРАЖАЮЩИЙ И ПРИНИМАЮЩИЙ СТАТИСТИКУ */

using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {
	
	//Статическая переменная, которая содержит количество очков
	public static int Score = 0;
	
	//ВНИМАНИЕ! Для реализации статических переменных стоит убедиться, что данное поведение будет существовать на сцене в единственном экземпляре
	
	// Use this for initialization
	void Start () {
		
	}
	
	// OnGUI вызывается в то время, когда необходимо прорисоват стандартное GUI Unity
	void OnGUI () {
		//Вывод надписи с количеством очков
		GUI.Label( new Rect( 0, 0, 100, 30 ), "Score: " + Score.ToString() );
	}
}
