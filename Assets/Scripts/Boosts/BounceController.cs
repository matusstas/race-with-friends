using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : BoostAction
{
    private GameObject car;
    public override void UseBoost(GameObject car){
        this.car=car;
        car.GetComponent<CarController>().bouncy=true;
        GlobalEvents.CarTurnEnd.AddListener(RemoveBounce);

    }

    private void RemoveBounce(){
        car.GetComponent<CarController>().bouncy=false;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveBounce);
    }
}
