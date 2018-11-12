using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	public float health = 250;
	public Image healthBar;
	public Weapon weapon;
	public float invulnDuration;
	private float invulnTimer;

	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = health/250f;
		if(invulnTimer > 0)
			invulnTimer -= Time.deltaTime;
	}

	void FireWeapon(){
		weapon.SendMessage("FireWeapon");
	}

	void TakeDamage(float damage){
		if(invulnTimer<= 0){
			health-=damage;
			invulnTimer = invulnDuration;
			if(health <= 0)
				Destroy(gameObject);
		}
		
	}
}
