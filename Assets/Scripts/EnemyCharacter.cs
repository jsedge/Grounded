using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character {

	public float damage;

	void OnTriggerStay(Collider other){
		if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Squad")){
			other.gameObject.SendMessage("TakeDamage", damage);
		}
	}
}
