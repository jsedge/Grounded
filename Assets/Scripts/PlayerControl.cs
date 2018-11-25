using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1.0f;
	private float gravity;
	private bool onGround = true;
	public CharacterController controller;
	private PlayerCharacter playerCharacter;


	// Use this for initialization
	void Start () {
		controller = GetComponent(typeof(CharacterController)) as CharacterController;
		Debug.Log(controller);
		playerCharacter = GetComponent(typeof(PlayerCharacter)) as PlayerCharacter;
		gravity = LevelManager.instance.gravity;
	}

	public void UpdateController(){
		controller = GetComponent(typeof(CharacterController)) as CharacterController;
		Debug.Log(controller);
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
		}else if(Input.GetButton("NextMember")){
			SquadManager.instance.NextMember();
		}else if(Input.GetButton("Toggle Light")){
			SquadManager.instance.ToggleLights();
		}
	}
}
