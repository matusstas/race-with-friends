using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecisionController : BoostAction
{
    private GameObject[] sliders;
    public override void UseBoost(GameObject car){
        // boost slows the moving pickers to half speed to select speed and angle
        // giving the player more control
        
        Debug.Log("Precision");
        sliders=GameObject.FindGameObjectsWithTag("Slider");
        
        // iterate over the sliders and modify their moving speeds by half
        foreach (GameObject slider in sliders){
            SliderController controller=slider.GetComponent<SliderController>();
            controller.speed/=2;
        }
        GlobalEvents.CarTurnEnd.AddListener(RemovePrecision);
    }


    private void RemovePrecision(){
        // iterate over the sliders and return their moving speeds back to normal
        foreach (GameObject slider in sliders){
            SliderController controller=slider.GetComponent<SliderController>();
            controller.speed*=2;
        }

        GlobalEvents.CarTurnEnd.RemoveListener(RemovePrecision);
    }
}
