using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour {

	public float health = 25f;

	public void TakeDamage(float damageTaken){
		Debug.Log("Ouch!");
		health-=damageTaken;
	}
}
