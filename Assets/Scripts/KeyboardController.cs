using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardController : MonoBehaviour
{
    public CarsController carsController;
    public GuiController guiController;

    // Start is called before the first frame update
    void Start()
    {
        // set frame rate to 60
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // go to next car
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space");
            carsController?.selectedCar.GetComponent<CarController>().NextState();
            Debug.Log("space pressed");
        }

        // use boost
        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Debug.Log("enter or return pressed");
            carsController?.selectedCar.GetComponent<CarController>().UseBoost();
            guiController?.HideBoost();

        }

        // show controlls
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("h pressed");
            guiController?.ShowControlls();
        }
    }
}
