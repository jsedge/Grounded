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
		
	// Update is called once per frame
	void Update () {
		if(target != null && !inTarget){
			transform.LookAt(target.transform);
			Vector3 dir = transform.forward;
			dir.y -= gravity;
			dir*=speed*Time.deltaTime;
			characterController.Move(dir);
			if(!animator.isPlaying){
				animator.Play("Walk");
			}
		}else{
			animator.Play("Idle");
		}
		
	}

}
