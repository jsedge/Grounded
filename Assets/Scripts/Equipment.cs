using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, Item {

    public float maxCooldown;
    private float cooldown;
    public float maxDuration;
    private float duration;
    private bool active = false;
    private GameObject attachedCharacter;

    void Start()
    {
        if (transform.parent.gameObject.CompareTag("Player"))
            UIManager.instance.UpdateEquipmentName(gameObject.name);
    }

    void Update()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
            duration -= Time.deltaTime;
            if (transform.parent.gameObject.CompareTag("Player"))
                UIManager.instance.UpdateEquipmentCooldown(cooldown, maxCooldown);
        }
        if (duration <= 0 && active)
        {
            gameObject.SendMessage("Deactivate", attachedCharacter);
            active = false;
        }
    }

    public void OnPickup (GameObject character) {
        // Character class
        Character charClass = character.GetComponent<Character>();

        // Move old equipment
        charClass.equipment.transform.parent = null;
        charClass.equipment.transform.position = gameObject.transform.position;

        // Move new equipment
        gameObject.transform.parent = character.transform;
        gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        // Set scale of equipment
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        charClass.equipment.transform.localScale = new Vector3(1f, 1f, 1f) ;

        // "Drop" the current equipment
        charClass.equipment.SendMessage("OnDrop", character);

        // Set the new equipment as the character's current equipment
        charClass.equipment = gameObject;

        // Update the UI equipment name
        UIManager.instance.UpdateEquipmentName(gameObject.name);

        // Update the UI equipment cooldown
        UIManager.instance.UpdateEquipmentCooldown(cooldown, maxCooldown);

        attachedCharacter = character;
    }
	
	public void OnDrop (GameObject character) { }

    public void OnUse(GameObject character)
    {
        if (cooldown <= 0)
        {
            cooldown = maxCooldown;
            duration = maxDuration;
            active = true;
            gameObject.SendMessage("Activate", character);
        }
    }

    public void Activate(GameObject character) { }

    public void Deactivate(GameObject character) { }

}
