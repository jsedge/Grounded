using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			GameManager.instance.ToggleLevelSelect();
		}
	}
}
