using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : BoostAction
{
    
    public override void UseBoost(GameObject car){
        Debug.Log("HC HEAL");
        car.GetComponent<CarController>().health=100;
    }
}
