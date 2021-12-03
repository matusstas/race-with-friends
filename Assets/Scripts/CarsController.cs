using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    public List<GameObject> cars;
    public GameObject selectedCar = null;
    private int selectedCarIndex = -1;  // -1 means no car selected

    // this controller expects that at least one car was created in another controller (in Awake()) with tag "Car" 
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("Car"));
        SelectNextCar();
    }

    void Update()
    {
        if (selectedCar == null) 
        {
            SelectNextCar();
        }
    }

    // select the next car
    public void SelectNextCar()
    {
        if (cars.Count > 0)
        {
            selectedCarIndex++;
            if (selectedCarIndex >= cars.Count)
            {
                selectedCarIndex = 0;
            }
            selectedCar = cars[selectedCarIndex];

            if (selectedCar == null)
            {
                SelectNextCar();
            }
            else
            {
                UpdateIsSelectedAttribute();
            }
        }
    }

    // set isSelected propertyto selectedCar
    private void UpdateIsSelectedAttribute()
    {
        foreach (GameObject car in cars)
        {
            if (car != null)
            {
                CarController carController = car.GetComponent<CarController>();
                carController.isSelected = car == selectedCar;
            }
        }
    }
}

