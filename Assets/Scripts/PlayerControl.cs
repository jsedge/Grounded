using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1.0f;
	// Gravity might want to come from the planet/area for all actors
	public float gravity = 1.0f;
	private bool onGround = true;
	private CharacterController controller;
	private PlayerCharacter playerCharacter;


	// Use this for initialization
	void Start () {
		controller = GetComponent(typeof(CharacterController)) as CharacterController;
		playerCharacter = GetComponent(typeof(PlayerCharacter)) as PlayerCharacter;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if(!onGround)
			moveDir.y-=gravity; 

		moveDir = transform.TransformDirection(moveDir);
		moveDir*=Time.deltaTime*speed;
		var flags = controller.Move(moveDir);
		onGround = (flags & CollisionFlags.CollidedBelow)!=0;

		if(Input.GetButton("Fire1")){
			gameObject.SendMessage("FireWeapon");
			//playerCharacter.weapon.FireWeapon(transform);
		}
	}
}
