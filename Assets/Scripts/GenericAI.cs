using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAI : MonoBehaviour {

	public bool inTarget = false;
	public GameObject target;
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
