using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoostAction : MonoBehaviour
{
    // Boosts can only be activated in one turn at a time
    // the player can always only have one boost in the ‘inventory’ and can use it at any time
    public abstract void UseBoost(GameObject car);
}
