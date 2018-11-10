using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public string axis;
	public float sensitivityX;
	public float sensitivityY;
	public bool useJoystick;
	// Update is called once per frame
	void Update () {
		// Get the input from the Joystick or Mouse axis
		float x,y;
		if(!useJoystick){
			x = Input.GetAxis("Mouse X") * sensitivityX;
			y = -Input.GetAxis("Mouse Y") * sensitivityY;
		}else{
			x = Input.GetAxis("Joystick X") * sensitivityX;
			y = Input.GetAxis("Joystick Y") * sensitivityY;
		}
		

		// Choose which axis this is set to move around
		if(axis == "X")
			transform.Rotate(0,x,0);
		else if(axis == "Y")
			transform.Rotate(y,0,0);
	}
}
