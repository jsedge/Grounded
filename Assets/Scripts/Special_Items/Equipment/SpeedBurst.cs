using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBurst : Equipment {

    public float speedChange;

    public void Activate(GameObject character)
    {
        Character charClass = character.GetComponent<Character>();

        charClass.speed += speedChange;
    }

    public void Deactivate(GameObject character)
    {
        Character charClass = character.GetComponent<Character>();

        charClass.speed -= speedChange;
    }
}
