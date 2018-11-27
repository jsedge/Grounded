using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Image healthBar;
	public Image weaponInfo;
	public Text weaponName;
	public static UIManager instance;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(gameObject);
			return;
		}
	}
	
	public void UpdatePlayerHealth(float current, float max){
		healthBar.fillAmount = current/max;
	}

	public void UpdateWeaponCooldown(float current, float total){
		weaponInfo.fillAmount = (total-current)/total;
	}

	public void UpdateWeaponName(string name){
		weaponName.text = name;
	}
}
