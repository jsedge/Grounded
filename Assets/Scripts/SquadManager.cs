using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour {
	public List<GameObject> squad;
	public int player = 0;
	public static SquadManager instance;
	public float swapCooldown;
	private float swapTimer;
	public float lightCooldown;
	private float lightTimer;
	

	void Start(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(gameObject);
			return;
		}
	}

	void Update(){
		if(swapTimer>=0)
			swapTimer-=Time.deltaTime;
		if(lightTimer >= 0)
			lightTimer-=Time.deltaTime;
	}

	public GameObject GetPlayer(){
		return squad[player];
	}

	void OnLevelLoad(){
		foreach(var member in squad){
			member.SetActive(true);
			member.transform.position = gameObject.transform.position;
		}
	}

	public void NextMember(){
		if(swapTimer<=0){
			if(player + 1 < squad.Count){
				SelectMember(player+1);
				player++;	
			}else{
				SelectMember(0);
				player = 0;
			}
			
			swapTimer=swapCooldown;
		}
		
	}

	public void FollowPlayer(){
		for(int i = 0; i < squad.Count; i++){
			if(i == player)
				continue;
			
		}
	}

	public void ToggleLights(){
		if(lightTimer<=0){
			Debug.Log("Toggling Lights");
			foreach(var member in squad){
				var light = member.GetComponent("Light") as Light;
				light.enabled = !light.isActiveAndEnabled;
			}
			lightTimer = lightCooldown;
		}
		
	}

	public void SelectMember(int member){
		// Grab a reference to the squad member we're switching to and the current one
		GameObject current = squad[player];
		GameObject next = squad[member];

		// Update tags 
		current.tag = "Squad";
		next.tag = "Player";

		// Toggle controls
		current.GetComponent<PlayerControl>().enabled = false;
		next.GetComponent<PlayerControl>().enabled = true;
		current.GetComponent<MouseLook>().enabled = false;
		next.GetComponent<MouseLook>().enabled = true;

		// Toggle the AI
		current.GetComponent<RangedAI>().enabled = true;
		next.GetComponent<RangedAI>().enabled = false;

		// Grab a reference to the Character component so we don't need to look it up several times
		PlayerCharacter curChar = current.GetComponent<PlayerCharacter>(),
			nextChar = next.GetComponent<PlayerCharacter>();

		// Toggle if they are a player
		curChar.isPlayer = false;
		nextChar.isPlayer = true;

		// Toggle weapon control
		curChar.weapon.GetComponent<MouseLook>().enabled = false;
		nextChar.weapon.GetComponent<MouseLook>().enabled = true;

		// Force an update of the UI
		UIManager.instance.UpdatePlayerHealth(nextChar.health,250);
		UIManager.instance.UpdateWeaponName(nextChar.weapon.gameObject.name);
		// This makes the cd bar full, if it shouldnt be itll be overwritten by the update immediately so its fine
		UIManager.instance.UpdateWeaponCooldown(0,1); 

		// Move the camera to the newly controlled squad member, keeping its local position
		current.transform.Find("Camera").SetParent(next.transform, false);
	}
}
