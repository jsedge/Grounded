using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float health;
	public GameObject weapon;
    public GameObject equipment;
	public float invulnDuration;
    public float pickupRange;
    public float speed = 10f;
	private float invulnTimer;
	
	public virtual void Die(){
		Destroy(gameObject);
	}

	void Update () {
		if(invulnTimer > 0)
			invulnTimer -= Time.deltaTime;
	}

	public virtual void TakeDamage(float damageTaken){
		if(invulnTimer<= 0){
			health-=damageTaken;
			invulnTimer = invulnDuration;
			if(health <= 0)
				Die();
		}
	}

	public void FireWeapon(){
		weapon.SendMessage("FireWeapon");
	}

    public void UseEquipment()
    {
        equipment.SendMessage("OnUse", gameObject);
    }

    public void PickupItem(){
        RaycastHit hit;
        if (Physics.Raycast(weapon.transform.position, -weapon.transform.up, out hit, pickupRange))
        {
            Debug.DrawLine(-weapon.transform.up, -weapon.transform.up*pickupRange, Color.yellow, 5);
            // Check item type
            if (hit.collider.gameObject.CompareTag("Item"))
            {
                hit.collider.gameObject.SendMessage("OnPickup", gameObject);
            }
        }
    }

	public bool CanHit(Transform target){
		if(weapon==null)
			return true;
		
		var weaponInfo = weapon.GetComponent(typeof(Weapon)) as Weapon;
		if(Vector3.Distance(transform.position,target.position) <= weaponInfo.range)
			return true;
		return false;
	}
	
}
