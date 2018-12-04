using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour, Item {

    public float healthIncrease;

    public void OnPickup(GameObject character)
    {
        character.SendMessage("TakeDamage", -healthIncrease);

        Destroy(gameObject);
    }

    public void OnDrop(GameObject character) { }

    public void OnUse(GameObject character) { }

}
