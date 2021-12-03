using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    public CarsController carsController;

    public Slider sliderForce;
    public Slider sliderAngle;
    private SliderForceController sliderForceController;
    private SliderAngleController sliderAngleController;


    public Text healthText;
    public Text winnerText;


    // Start is called before the first frame update
    void Start()
    {
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngle.interactable = false;
        sliderForce.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinCondition();
        UpdateCarHealthGUI();
        UpdateSlidersGUI();
    }

    // update slider values based on previewSpeed and previewRotation of car tagged with "ActiveCar"
    private void UpdateSlidersGUI()
    {
        GameObject selectedCar = carsController.selectedCar;
        if (selectedCar != null)
        {
            CarController selectedCarController = selectedCar.GetComponent<CarController>();
            selectedCarController.previewAngle = sliderAngle.value;
            selectedCarController.previewForce = sliderForce.value;
        }
    }

    public void CarStateChanged()
    {
        UpdateSlidersGUI();
        // get currentCar state
        CarState currentCarState = carsController.selectedCar.GetComponent<CarController>().carState;
        if (currentCarState == CarState.SELECTING_ANGLE)
        {

            sliderForceController.Pause();
            sliderAngleController.Continue();
        }
        else if (currentCarState == CarState.SELECTING_SPEED)
        {
            sliderForceController.Continue();
            sliderAngleController.Pause();
        }
        else
        {
            sliderAngleController.Pause();
            sliderForceController.Pause();
        }


    }

    private void UpdateCarHealthGUI()
    {
        // update car health in gui
        string hText = "Health:\n";
        foreach (GameObject car in carsController.cars)
        {
            if (car != null)
            {
                // get hex color of car and add it to <color> tag
                hText += "<color=#" + ColorUtility.ToHtmlStringRGB(car.GetComponent<SpriteRenderer>().color) + ">" + car.GetComponent<CarController>().name + "</color> " + Mathf.Round(car.GetComponent<CarController>().health) + "\n";
            }
        }
        healthText.text = hText + "";
    }


    private void CheckWinCondition()
    {
        // pause the game if only one car is left
        if (carsController.cars.Count == 1)
        {
            // get first carController
            GameObject winner = carsController.cars[0];

            // set winnerText to winning car
            winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().name + "</color> " + " won!";
            Time.timeScale = 0;
        }

        // or if no one is left
        if (carsController.cars.Count == 0)
        {
            winnerText.text = "No one won!";
            Time.timeScale = 0;
        }
    }
}
