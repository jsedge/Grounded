using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
	
	public float range;
	public float damage;
	public float fireRate;
	private float fireCooldown;

	// Use this for initialization
	public void FireWeapon(){
		if(fireCooldown<=0){
			Debug.Log("Pew pew!");
			Debug.DrawRay(transform.position,-transform.up * range, Color.green, 1.5f);
			fireCooldown = fireRate;
			RaycastHit hit;
			if(Physics.Raycast(transform.position, -transform.up, out hit, range)){
				if(hit.collider.gameObject.CompareTag("Enemy")){
					hit.collider.gameObject.SendMessage("TakeDamage", damage);
				}
			} 
		}else{
			fireCooldown-=Time.deltaTime;
		}
		
	}
}
