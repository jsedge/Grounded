using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAcquisition : MonoBehaviour {
	
	private List<GameObject> possibleTargets;
	public float reassessmentDelay = 2.0f;
	private float reassessmentCooldown;
	private GameObject parent;

	void Start(){
		possibleTargets = new List<GameObject>();
		parent = gameObject.transform.parent.gameObject;
	}
		
	// Update is called once per frame
	void Update () {
		if(reassessmentCooldown <= 0){
			AssessTargets();
		}else{
			reassessmentCooldown -= Time.deltaTime;
		}
	}

	void AssessTargets(){
		GameObject bestTarget = null;
		float bestScore = 1;
		foreach(GameObject possibleTarget in possibleTargets){
			if(possibleTarget == null){
				// remove thing dunno lmao
				continue;
			}
			float score = 0;
			if(possibleTarget.CompareTag("Player")){
				score = 5;
			}else if(possibleTarget.CompareTag("Squad")){
				score = 3;
			}

			if(score > bestScore){
				bestScore = score;
				bestTarget = possibleTarget;
			}
		}
		if(bestTarget != null){
			parent.SendMessage("UpdateTarget", bestTarget);
		}else{
			parent.SendMessage("RemoveTarget");
		}
		
		reassessmentCooldown = reassessmentDelay;
	}

	void OnTriggerEnter(Collider other){
		possibleTargets.Add(other.gameObject);
	}

	void OnTriggerExit(Collider other){
		possibleTargets.Remove(other.gameObject);
	}
}
