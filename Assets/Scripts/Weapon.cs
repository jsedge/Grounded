using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, Item{
	
	public float range;
	public float damage;
	public float fireRate; 
	public float weightPenalty;
	private float fireCooldown;

	void Start(){
		if(transform.parent.gameObject.CompareTag("Player"))
				UIManager.instance.UpdateWeaponName(gameObject.name);
	}

	void Update(){
		if(fireCooldown >= 0){
			fireCooldown-=Time.deltaTime;
			if(transform.parent.gameObject.CompareTag("Player"))
				UIManager.instance.UpdateWeaponCooldown(fireCooldown, fireRate);
		}
	}

	// Use this for initialization
	public void FireWeapon(){
		if(fireCooldown<=0){ 
			Debug.DrawRay(transform.position,-transform.up * range, Color.green);
			fireCooldown = fireRate;
			RaycastHit hit;
			if(Physics.Raycast(transform.position, -transform.up, out hit, range)){
				var y = hit.point;
				y.y+=25;
				//Debug.DrawLine(hit.point, y, Color.red,5);
				if(hit.collider.gameObject.CompareTag("Enemy")){
					hit.collider.gameObject.SendMessage("TakeDamage", damage);
				}
			} 
		}
		
	}

    public virtual void OnPickup(GameObject character)
    {
        // Character class
        Character charClass = character.GetComponent<Character>();

        // Move old weapon
        charClass.weapon.transform.parent = null;
        charClass.weapon.transform.position = gameObject.transform.position;
        charClass.weapon.GetComponent<MouseLook>().enabled = false;
		charClass.speed-=weightPenalty;

        // Move new weapon
        gameObject.transform.parent = character.transform;
        gameObject.transform.localPosition = new Vector3(0.46f, 0.592f, 0.312f);
        gameObject.GetComponent<MouseLook>().enabled = true;

        // Set rotation of weapons
        Quaternion temp = gameObject.transform.rotation;
        gameObject.transform.rotation = charClass.weapon.transform.rotation;
        charClass.weapon.transform.rotation = temp;

        // "Drop" the current weapon
        charClass.weapon.SendMessage("OnDrop", character);

        // Set the new weapon as the character's current weapon
        charClass.weapon = gameObject;

        // Update the UI weapon name
        UIManager.instance.UpdateWeaponName(gameObject.name);
    }

    public virtual void OnDrop(GameObject character) {
		Character charClass = character.GetComponent<Character>();

        charClass.speed += weightPenalty;
	 }

    public virtual void OnUse(GameObject character) { }

}
