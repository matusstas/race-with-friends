using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    public List<GameObject> cars;

    [HideInInspector]
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

    }


    // this controller expects that at least one car was created in another controller (in Awake()) with tag "Car" 
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("Car"));
        if (PlayerPrefs.GetString("gameMode")=="race")
            for (int i = 1; i < cars.Count; i++)
            {
                cars[i].active=false;
            }
        SelectNextCar();
    }

    void Update()
    {
        RemoveDestroyedCars();  // it should work without this line (only using CarDestroyed event), but it doesn't work without it if multiple cars are destroyed in one frame
    }

    private void RemoveDestroyedCars()
    {
        int newIndex = selectedCarIndex;

        for (int i = 0; i < cars.Count; i++)
        {
            if (cars[i] == null)
            {
                if (i < selectedCarIndex)
                {
                    newIndex--;
                }
                cars.RemoveAt(i);
            }
        }
        if (selectedCar == null)
        {
            SelectNextCar();
        }
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
        if (!selectedCar.active)
            selectedCar.active=true;

        selectedCar.GetComponent<CarController>().NextState();
    }
}

