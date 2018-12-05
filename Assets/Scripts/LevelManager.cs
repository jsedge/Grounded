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
	public List<GameObject> enemyTypes;
	public GameObject enemyObject;
	public string infoText;
	// Use this for initialization
	void Awake () {
		if(instance == null){
			instance = this;
			if(!isStartLevel)
				GameManager.instance.ToggleLevelSelect();
			var squadManager = GameObject.Find("Squad");
			squadManager.SendMessage("OnLevelLoad");
			InitializeLevel();
		}else{
			Destroy(gameObject);
			return;
		}
	}

	void InitializeLevel(){
		var spawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
		foreach(var spawn in spawns){
			var numEnemies = Random.Range(4,10);
			for(int i = 0; i <= numEnemies; i++){
				var enemy = enemyTypes[Random.Range(0,enemyTypes.Count)];
				var location = spawn.transform.position;
				location += new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
				var newEnemy = Instantiate(enemy,location, new Quaternion());
				newEnemy.transform.SetParent(enemyObject.transform);

			}
		}

		//UIManager.instance.UpdateInformation(infoText);
	}
	
}
