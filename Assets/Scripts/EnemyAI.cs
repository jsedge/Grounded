using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public float speed;

	private CharacterController characterController;
	private Animation animator;

	void Start(){
		characterController = GetComponent(typeof(CharacterController)) as CharacterController;
		animator = GetComponent(typeof(Animation)) as Animation;
	}
		
	// Update is called once per frame
	void Update () {
		if(target != null){
			transform.LookAt(target);
			characterController.Move(transform.forward * Time.deltaTime * speed);
			if(!animator.isPlaying){
				animator.Play("Walk");
			}
		}else{
			animator.Play("Idle");
		}
		
	}

	void UpdateTarget(GameObject newTarget){
		target = newTarget.transform;
	}

	void RemoveTarget(){
		target = null;
	}
}
