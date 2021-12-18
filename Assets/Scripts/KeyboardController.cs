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
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space");
            carsController?.selectedCar.GetComponent<CarController>().NextState();
            Debug.Log("space pressed");
        }

        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Debug.Log("enter or return pressed");
            carsController?.selectedCar.GetComponent<CarController>().UseBoost();
            guiController?.HideBoost();

        }        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("h pressed");
            guiController?.ShowControlls();
            //PlayerPrefs.SetInt("isHPressed", 1);
            //SceneManager.LoadScene("ControlsScene");
        }
    }
}
