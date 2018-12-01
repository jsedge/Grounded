using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSpeed : Equipment {

    public float speedChange = 4.0f;

    public void OnPickup(GameObject character)
    {
        // Character class
        Character charClass = character.GetComponent<Character>();

        base.OnPickup(character);

        charClass.speed += speedChange;
    }

    public void OnDrop(GameObject character)
    {
        Character charClass = character.GetComponent<Character>();

        charClass.speed -= speedChange;
    }

}
