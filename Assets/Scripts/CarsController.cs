using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    public List<GameObject> cars;
    public GameObject selectedCar = null;
    private int selectedCarIndex = -1;  // -1 means no car selected

    // subscribe to events
    void Awake()
    {
        // add listener
        GlobalEvents.CarStateChanged.AddListener(CarStateChanged);
        GlobalEvents.CarDestroyed.AddListener(CarDestroyed);
        GlobalEvents.CarTurnEnd.AddListener(SelectNextCar);
    }


    // onDestroy unsubscribe from events
    void OnDestroy()
    {
        // remove listener
        GlobalEvents.CarStateChanged.RemoveListener(CarStateChanged);
        GlobalEvents.CarDestroyed.RemoveListener(CarDestroyed);
        GlobalEvents.CarTurnEnd.RemoveListener(SelectNextCar);
    }

    private void CarStateChanged(CarState carState)
    {
        // if (carState == CarState.NOT_SELECTED)
        // {
        //     SelectNextCar();
        // }
    }


    // this controller expects that at least one car was created in another controller (in Awake()) with tag "Car" 
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("Car"));
        SelectNextCar();
    }

    void Update()
    {
        
    }

    // delete destroyed cars from list
    private void CarDestroyed(GameObject carToBeDestroyed)  // this car will be destroyed at the end of the frame
    {
        int newIndex = selectedCarIndex;

        // find index in a list
        int indexOfToBeDestroyedCar = cars.IndexOf(carToBeDestroyed);
        cars.RemoveAt(indexOfToBeDestroyedCar);
        if (indexOfToBeDestroyedCar < selectedCarIndex)  // change selected car index if car deletion shifted it
        {
            newIndex--;
        }

        selectedCarIndex = newIndex;

        if (selectedCar == null)
        {
            SelectNextCar();
        }
    }

    public void SelectNextCar()
    {
        // select next car
        selectedCarIndex++;
        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        selectedCar = cars[selectedCarIndex];

        selectedCar.GetComponent<CarController>().NextState();
    }
}

