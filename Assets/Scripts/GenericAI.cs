using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAI : MonoBehaviour {
	/* Generic AI class that all AI behaviour should extend
	 * Performs a set of actions defined in the subclass each frame
	 */

	public bool inTarget = false;
	public GameObject target;

	public void Update(){		
		DecideActions();
	}

	/*
	For the generic AI every frame we decide our actions, assuming standard actions of 
	Attack and Attack. This can be extended to include others, but make sure to call the base
	method as well
	*/
	public virtual void DecideActions(){
		Move();
		Attack();
	}

	// Default actions are to do nothing
	public virtual void Move(){
		return;
	}

	public virtual void Attack(){
		return;
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
