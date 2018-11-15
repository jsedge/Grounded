using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Character {
	public Image healthBar;
	public bool isPlayer;

	
	public override void TakeDamage(float damageTaken){
		base.TakeDamage(damageTaken);
		if(isPlayer)
			UpdateHealthBar();
	}

	public void UpdateHealthBar(){
		healthBar.fillAmount = health/250;
	}
}
