using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			GameManager.instance.OpenLevel("CrashSite");
		}
	}
}
