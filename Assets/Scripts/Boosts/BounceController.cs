using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : BoostAction
{
    public PhysicsMaterial2D bounceMat;
    private GameObject car;
    public override void UseBoost(GameObject car){
        // boost ensures that the player bounces on the first impact on the wall
        // which allows the player to help overcome a sharp turn.

        Debug.Log("Bounce");
        this.car=car;
        car.GetComponent<CarController>().bouncy=true;
        car.GetComponent<CapsuleCollider2D>().sharedMaterial=bounceMat;
        GlobalEvents.CarTurnEnd.AddListener(RemoveBounce);

    }

    private void RemoveBounce(){
        // return values back to normal
        car.GetComponent<CarController>().bouncy=false;
        car.GetComponent<CapsuleCollider2D>().sharedMaterial=null;
        GlobalEvents.CarTurnEnd.RemoveListener(RemoveBounce);
    }
}
