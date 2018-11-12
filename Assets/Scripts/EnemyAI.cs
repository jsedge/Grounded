using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public GameObject target;
	public float speed;
	private float gravity;
	private CharacterController characterController;
	private Animation animator;
	private bool inTarget = false;

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

	void UpdateTarget(GameObject newTarget){
		if(target == newTarget){
			return;
		}
		target = newTarget;
		inTarget = false;
	}

	void RemoveTarget(){
		target = null;
		inTarget = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject == target){
			inTarget = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject == target)
			inTarget = false;
	}
}
