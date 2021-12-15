using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : BoostAction
{
    private GameObject car;
    public override void UseBoost(GameObject car){
        this.car=car;
        car.GetComponent<CarController>().shield=true;
        GlobalEvents.CarTurnEnd.AddListener(RemoveShield);

    }

    private void RemoveShield(){
        car.GetComponent<CarController>().shield=false;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveShield);
    }
}
