using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {

	public float range;
	public float damage;
	public float fireRate;
	private float fireCooldown;

	public Weapon(float range, float damage, float fireRate){
		this.range = range;
		this.damage = damage;
		this.fireRate = fireRate;
		this.fireCooldown = 0;
	}
	// Use this for initialization
	public void FireWeapon(Transform position){
		if(fireCooldown<=0){
			Debug.Log("Pew pew!");
			Debug.DrawRay(position.position,position.forward * range, Color.green, 1.5f);
			fireCooldown = fireRate;
			RaycastHit hit;
			if(Physics.Raycast(position.position, position.forward, out hit, range)){
				if(hit.collider.gameObject.CompareTag("Enemy")){
					hit.collider.gameObject.SendMessage("TakeDamage", damage);
				}
			} 
		}else{
			fireCooldown-=Time.deltaTime;
		}
		
	}
}
