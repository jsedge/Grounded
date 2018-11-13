using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float health;
	public GameObject weapon;
	public float invulnDuration;
	private float invulnTimer;
	
	void Die(){
		Destroy(gameObject);
	}

	void Update () {
		if(invulnTimer > 0)
			invulnTimer -= Time.deltaTime;
	}

	public virtual void TakeDamage(float damageTaken){
		Debug.Log("ouch?");
		if(invulnTimer<= 0){
			Debug.Log("Ouch!");
			health-=damageTaken;
			invulnTimer = invulnDuration;
			if(health <= 0)
				Die();
		}
	}

	public void FireWeapon(){
		weapon.SendMessage("FireWeapon");
	}

	public bool CanHit(Transform target){
		if(weapon==null)
			return true;
		
		var weaponInfo = weapon.GetComponent(typeof(Weapon)) as Weapon;
		if(Vector3.Distance(transform.position,target.position) <= weaponInfo.range)
			return true;
		return false;
	}
	
}
