using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public class AutodromController : MonoBehaviour
{
    // public AutodromInit autodromInit;

    // public List<GameObject> cars;

    // // enum of states anglePreview, forcePreview, animating

    // private enum State { ANGLE_PREVIEW, FORCE_PREVIEW, ANIMATING, CHOOSING_NEW_CAR};
    // private State state = State.ANGLE_PREVIEW;
    // public int currentCarIndex = 0;


    // private int selectedCarIndex = -1;
    // private CarController selectedCarController;

    // // Start is called before the first frame update
    void Start()
    {
    //     Debug.Log("carcount from autodrom:" + autodromInit.carCount);
    //     // get all cars with tag "Car"
    //     GameObject[] carObjects = GameObject.FindGameObjectsWithTag("Car");
    //     cars = new List<GameObject>(carObjects);

    //     NextCar();  // select the first car
    }

    // // Update is called once per frame
    void Update()
    {
    //     // get "SelectedCar" based on tag"
    //     GameObject selectedCar = GameObject.FindGameObjectWithTag("SelectedCar");

    //     // if the selected car is not null
    //     if (selectedCar != null)
    //     {
    //         // get the car controller
    //         selectedCarController = selectedCar.GetComponent<CarController>();

    //         HideDeadCars();
    //     }
    }



    // public void ConfirmSpeedOrAngle()
    // {
    //     Debug.Log("ConfirmSpeedOrAngle");

    //     if (state == State.ANGLE_PREVIEW)
    //     {
    //         // sliderForceController.Continue();
    //         // sliderAngleController.Pause();
    //         state = State.FORCE_PREVIEW;

    //         return;
    //     }
    //     else if (state == State.FORCE_PREVIEW)
    //     {
    //         // sliderForceController.Pause();
    //         state = State.ANIMATING;
    //         StartCoroutine(selectedCarController.MoveAnimate(this));
    //         return;
    //     }
    //     else if (state == State.ANIMATING)
    //     {
    //         return;
    //     }
    //     // animating to false will be set at the end of the animation
    // }


    // public void UseBoost()
    // {
    //     Debug.Log("ENTER");
    //     BoostAction boost = selectedCarController.GetComponent<CarController>().boost;
    //     //string boost=selectedCarController.GetComponent<CarController>().boost;
    //     Debug.Log(boost);
    //     if (boost != null)
    //     {
    //         Debug.Log("POUZITY BOOST: " + boost);
    //         selectedCarController.GetComponent<CarController>().boost.UseBoost();
    //     }
    //     else
    //     {
    //         Debug.Log("NEMAS");
    //     }
    // }


    // private void HideDeadCars()
    // {
    //     // if any car health is below 0, hide it
    //     // TODO: properly destroy it
    //     for (int i = 0; i < cars.Count; i++)
    //     {
    //         GameObject car = cars[i];
    //         if (car.GetComponent<CarController>().health <= 0)
    //         {
    //             car.GetComponent<CarController>().HideCar();
    //             cars.Remove(car);
    //         }
    //     }
    // }

    // public void NextCar()
    // {
    
    //     // if no cars in the list
    //     if (cars.Count == 0)
    //     {
    //         Debug.Log("No cars");
    //     }

    //     // switch control to the next car
    //     selectedCarIndex++;
    //     // sliderAngleController.Continue();
    //     if (selectedCarIndex >= cars.Count)
    //     {
    //         selectedCarIndex = 0;
    //     }

    //     Debug.Log("Selected car index: " + selectedCarIndex);
    // }
}
