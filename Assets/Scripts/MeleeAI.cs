using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : GenericAI {
	/*
	Extension of generic AI, this will mindlessly run at the target then stop when it hits
	*/
	
	public float speed;
	public bool flying = false;
	private float gravity;
	private CharacterController characterController;
	private Animation animator;
	private bool isWandering = false;
	private float timeSpentWandering = 0.0f;

	void Start(){
		characterController = GetComponent(typeof(CharacterController)) as CharacterController;
		animator = GetComponent(typeof(Animation)) as Animation;
		if(!flying)
			gravity = LevelManager.instance.gravity;
		else
			gravity = 0;
	}
		
	public override void Move(){
		// Melee does damage through contact, so only need to move
		Vector3 dir = new Vector3(0,-gravity,0);
		if(isWandering)
			timeSpentWandering+=Time.deltaTime;
		if(target != null){
			if(isWandering && Vector3.Distance(transform.position, target.transform.position) < 1.0f){
				StopWandering();
				return;
			}
			// Mindleslly charge the opponent until they collide, then stop for a bit
			transform.LookAt(target.transform);
			if(!inTarget){
				dir += transform.forward;
			}
			if(!animator.isPlaying)
				animator.Play("Move");
		}else{
			animator.Play("Idle");
		}

		dir*=speed*Time.deltaTime;
		var collision = characterController.Move(dir);
		if((collision & CollisionFlags.CollidedSides) != 0 && isWandering){
			StopWandering();
			StartWandering();
		}
	}

	public override void UpdateTarget(GameObject newTarget){
		if(isWandering){
			Destroy(target);
			isWandering = false;
		}else{
			base.UpdateTarget(newTarget);
		}

	}

	void StopWandering(){
		timeSpentWandering = 0;
		isWandering = false;
		Destroy(target);
	}

	void StartWandering(){
		isWandering = true;
		var location = transform.position;
		location+= new Vector3(Random.Range(-75,75),0,Random.Range(-75,75));
		target = new GameObject("Target");
		target.transform.position = location;
		target.transform.SetParent(transform);
	}

	public override void RemoveTarget(){
		if(isWandering && target !=null){
			if(Vector3.Distance(transform.position, target.transform.position) < 1.0f || timeSpentWandering > 6.0f){
				StopWandering();
			}
		
		}else if(!isWandering){
			StartWandering();
		}
	}

}
