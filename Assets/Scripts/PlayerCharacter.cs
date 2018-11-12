using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Character {
	public Image healthBar;

	
	public override void TakeDamage(float damageTaken){
		base.TakeDamage(damageTaken);
		healthBar.fillAmount = health/250;
	}
}
