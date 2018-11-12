using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAcquisition : MonoBehaviour {
	public List<string> tags;
	public List<int> weights;
	private Dictionary<string,int> targetWeights;
	private List<GameObject> possibleTargets;
	public float reassessmentDelay = 2.0f;
	private float reassessmentCooldown;
	private GameObject parent;

	void Start(){
		possibleTargets = new List<GameObject>();
		parent = gameObject.transform.parent.gameObject;
		targetWeights = new Dictionary<string, int>();
		for(int i = 0; i < tags.Count; i++){
			targetWeights[tags[i]] = weights[i];
		}
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
		// Start with a best score of 1, so if no "good" target is found, we assign none
		float bestScore = 1;
		foreach(GameObject possibleTarget in possibleTargets){
			if(possibleTarget == null){
				// remove thing dunno lmao
				continue;
			}
			float score = 0;
			if(targetWeights.ContainsKey(possibleTarget.tag)){
				score = targetWeights[possibleTarget.tag];
			}

			Debug.Log("Possible target with tag: " + possibleTarget.tag + " has a score of " + score);

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
