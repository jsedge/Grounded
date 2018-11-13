using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : GenericAI {
	public float speed;
	public string allyTag;
	private float gravity;
	private CharacterController characterController;
	private Character character;
	private float idealRange;

	// Use this for initialization
	void Start(){
		// Set up things we'll need, CharacterController for movement, character for their info
		characterController = GetComponent(typeof(CharacterController)) as CharacterController;
		character = GetComponent(typeof(Character)) as Character;
		
		// Grab the gravity for the current level
		gravity = LevelManager.instance.gravity;
		idealRange = (character.weapon.GetComponent("Weapon") as Weapon).range-2;
	}
	
	/*
	Implementation of movement for a generic ranged Actor
	Called each from the GenericAI
	*/
	public override void Move(){
		// To start, we apply gravity no matter what
		Vector3 dir = new Vector3(0,-gravity,0);

		if(target != null){
			// Only move if we have a target

			// First look at our distance to the target, and what we want it to be
			float distance = Vector3.Distance(transform.position, target.transform.position);
			float desiredDistance = target.tag == allyTag ? 10.0f : idealRange;

			// Look at our target
			transform.LookAt(target.transform);

			// Move closer or away based on if we want to get closer or less close
			if(distance > desiredDistance){
				dir += transform.forward;
			}else if( distance < desiredDistance){
				dir -= transform.forward;
			}
		}
		
		// Finally, apply the movements
		dir*=Time.deltaTime*speed;
		characterController.Move(dir);
	}

	public override void Attack(){
		// Nothing to attack then don't
		if(target == null)
			return;

		// Only attack if it will hit and is not the ally
		if(!target.CompareTag(allyTag) && character.CanHit(target.transform))
			character.FireWeapon();
	}
}
