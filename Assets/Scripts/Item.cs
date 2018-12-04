﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item {

    void OnPickup(GameObject character);

    void OnDrop(GameObject character);

    void OnUse(GameObject character);

}
