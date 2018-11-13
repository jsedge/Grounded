using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : GenericAI {
	/*
	Extension of generic AI, this will mindlessly run at the target then stop when it hits
	*/
	
	public float speed;
	private float gravity;
	private CharacterController characterController;
	private Animation animator;

	void Start(){
		characterController = GetComponent(typeof(CharacterController)) as CharacterController;
		animator = GetComponent(typeof(Animation)) as Animation;
		gravity = LevelManager.instance.gravity;
	}
		
	public override void Move(){
		// Melee does damage through contact, so only need to move
		Vector3 dir = new Vector3(0,-gravity,0);
		if(target != null){
			// Mindleslly charge the opponent until they collide, then stop for a bit
			transform.LookAt(target.transform);
			if(!inTarget){
				dir += transform.forward;
			}
			if(!animator.isPlaying)
				animator.Play("Walk");
		}else{
			animator.Play("Idle");
		}

		dir*=speed*Time.deltaTime;
		characterController.Move(dir);
	}

}
