using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour {

	public float health = 25f;

	public void TakeDamage(float damageTaken){
		Debug.Log("Ouch!");
		health-=damageTaken;
		if(health<=0){
			Die();	
		}
	}

	public void Die(){
		Destroy(gameObject);
	}
}
