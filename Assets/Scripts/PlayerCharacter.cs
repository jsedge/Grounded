using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	public float health = 250;
	public Image healthBar;
	public Weapon weapon;


	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = health/250f;
	}

	void FireWeapon(){
		weapon.SendMessage("FireWeapon");
	}
}
