using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	public float gravity;
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
			return;
		}
	}
	
}
