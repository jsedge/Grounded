using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	/* This class holds information for the current level, create a new one per scene
	* Describes behaviour such as the gravity on a per zone basis
	*/
	public static LevelManager instance;
	public bool isStartLevel = false;
	public float gravity;
	// Use this for initialization
	void Awake () {
		if(instance == null){
			instance = this;
			if(!isStartLevel)
				GameManager.instance.ToggleLevelSelect();
			var squadManager = GameObject.Find("Squad");
			squadManager.SendMessage("OnLevelLoad");
		}else{
			Destroy(gameObject);
			return;
		}
	}
	
}
