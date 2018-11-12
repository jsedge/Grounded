using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : GenericAI {
	public float speed;
	private float gravity;
	private CharacterController characterController;
	private Character character;

	// Use this for initialization
	void Start(){
		characterController = GetComponent(typeof(CharacterController)) as CharacterController;
		//animator = GetComponent(typeof(Animation)) as Animation;
		character = GetComponent(typeof(Character)) as Character;
		Debug.Log(LevelManager.instance);
		gravity = 1;//LevelManager.instance.gravity;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null && !character.CanHit(target.transform)){
			transform.LookAt(target.transform);
			Vector3 dir = transform.forward;
			dir.y -= gravity;
			dir*=speed*Time.deltaTime;
			characterController.Move(dir);
		}else if(target != null){
			character.FireWeapon();
		}else{
			
		}
		
	}
}
