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
				continue;
			}
			float score = 0;
			if(targetWeights.ContainsKey(possibleTarget.tag)){
				score = targetWeights[possibleTarget.tag];
			}
			float distance = Vector3.Distance(transform.position, possibleTarget.transform.position)/100f;
			score/=distance;

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
		if(other.gameObject == gameObject.transform.parent.gameObject){
			// Ignore the object itself (its parent really)
			return;
		}
		possibleTargets.Add(other.gameObject);
	}

	void OnTriggerExit(Collider other){
		possibleTargets.Remove(other.gameObject);
	}
}
