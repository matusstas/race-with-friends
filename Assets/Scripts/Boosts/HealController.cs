using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : BoostAction
{   
    public override void UseBoost(GameObject car){
        // Player will have the opportunity to repair his car by 100%
        
        Debug.Log("Heal");
        car.GetComponent<CarController>().health=100;
    }
}
