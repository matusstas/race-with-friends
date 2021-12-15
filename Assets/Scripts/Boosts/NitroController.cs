using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroController : BoostAction
{
    private GameObject car;
    public override void UseBoost(GameObject car){
        this.car=car;
        car.GetComponent<CarController>().force*=2f;
        GlobalEvents.CarTurnEnd.AddListener(RemoveNitro);

    }

    private void RemoveNitro(){
        car.GetComponent<CarController>().force/=2f;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveNitro);
    }
}
