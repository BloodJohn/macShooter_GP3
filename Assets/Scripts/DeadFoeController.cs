/* ПОВЕДЕНИЕ СМЕРТИ ВРАГА */

using UnityEngine;
using System.Collections;

public class DeadFoeController : MonoBehaviour {
	
	private AudioSource Sound; //Переменная с ссылкой на компонент, который воспроизводит аудио
	
	// Use this for initialization
	void Start () {
		//Получаем ссылку на компонент, который воспроизводит аудио, чтобы не искать его каждый раз в Update
		Sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//Проверка на факт того, что звук ещё играет
		if ( !Sound.isPlaying )
			Destroy( gameObject ); 	//Если нет - пора удалять gameObject
	}
}
