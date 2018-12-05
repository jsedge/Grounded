using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {

	public float delay = 5.0f;

	void Update(){
		if(delay >= 0){
			delay-=Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player") && delay <= 0){
			GameManager.instance.CompleteLevel(LevelManager.instance.levelName);
		}
	}
}
