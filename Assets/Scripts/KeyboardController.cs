using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{
    public CarsController carsController;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space");
            carsController.selectedCar.GetComponent<CarController>().NextState();
        }

        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            carsController.selectedCar.GetComponent<CarController>().UseBoost();
        }
    }
}
