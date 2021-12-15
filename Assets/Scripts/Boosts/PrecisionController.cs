using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecisionController : BoostAction
{
   
    private GameObject[] sliders;
    public override void UseBoost(GameObject car){
        Debug.Log("PRECISION");
        sliders=GameObject.FindGameObjectsWithTag("Slider");
        foreach (GameObject slider in sliders){

            SliderController controller=slider.GetComponent<SliderController>();
            controller.speed/=2;
        }
        GlobalEvents.CarTurnEnd.AddListener(RemovePrecision);
    }


    private void RemovePrecision(){

        foreach (GameObject slider in sliders){

            SliderController controller=slider.GetComponent<SliderController>();
            controller.speed*=2;
        }

        GlobalEvents.CarTurnEnd.RemoveListener(RemovePrecision);
    }
}
