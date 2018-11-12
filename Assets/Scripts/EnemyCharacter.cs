using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour {

	public float health = 25f;
	public float damage;

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

	void OnTriggerStay(Collider other){
		if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Squad")){
			other.gameObject.SendMessage("TakeDamage", damage);
		}
	}
}
