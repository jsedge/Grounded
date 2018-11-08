using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1.0f;
	private CharacterController controller;


	// Use this for initialization
	void Start () {
		controller = GetComponent(typeof(CharacterController)) as CharacterController;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDir = transform.TransformDirection(moveDir);
		moveDir*=Time.deltaTime*speed;
		var flags = controller.Move(moveDir);
	}
}
