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
			Debug.DrawRay(transform.position,-transform.up * range, Color.green);
			fireCooldown = fireRate;
			RaycastHit hit;
			if(Physics.Raycast(transform.position, -transform.up, out hit, range)){
				Debug.Log("I hit a " + hit.collider.gameObject.tag);
				var y = hit.point;
				y.y+=25;
				Debug.DrawLine(hit.point, y, Color.red,5);
				if(hit.collider.gameObject.CompareTag("Enemy")){
					hit.collider.gameObject.SendMessage("TakeDamage", damage);
				}
			} 
		}else{
			fireCooldown-=Time.deltaTime;
		}
		
	}
}
