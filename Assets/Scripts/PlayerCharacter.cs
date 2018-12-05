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
			UIManager.instance.UpdatePlayerHealth(health,250);
	}

	public override void Die(){
		// If it is the player, select the next squad mate before dying
		if(isPlayer){
			SquadManager.instance.NextMember();
		}
		SquadManager.instance.ReportDeath(gameObject);
		base.Die();
	}
}
