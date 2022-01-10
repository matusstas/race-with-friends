using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroController : BoostAction
{
    private GameObject car;
    public override void UseBoost(GameObject car){
        // When using the boost, 2 times higher speed is applied per move

        Debug.Log("Nitro");
        this.car=car;
        car.GetComponent<CarController>().force*=2f;
        GlobalEvents.CarTurnEnd.AddListener(RemoveNitro);

    }

    private void RemoveNitro(){
        // return values back to normal
        car.GetComponent<CarController>().force/=2f;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveNitro);
    }
}
