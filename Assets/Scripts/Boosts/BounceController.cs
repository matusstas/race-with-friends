using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : BoostAction
{
    
    public PhysicsMaterial2D bounceMat;
    private GameObject car;
    public override void UseBoost(GameObject car){
        this.car=car;
        car.GetComponent<CarController>().bouncy=true;
        car.GetComponent<CapsuleCollider2D>().sharedMaterial=bounceMat;
        GlobalEvents.CarTurnEnd.AddListener(RemoveBounce);

    }

    private void RemoveBounce(){
        car.GetComponent<CarController>().bouncy=false;
        car.GetComponent<CapsuleCollider2D>().sharedMaterial=null;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveBounce);
    }
}
