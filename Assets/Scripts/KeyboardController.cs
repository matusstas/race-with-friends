using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{

    public List<GameObject> cars;

    public Slider sliderForce;
    public Slider sliderAngle;
    private SliderForceController sliderForceController;
    private SliderAngleController sliderAngleController;
    private int selectedCarIndex = -1;
    private CarController selectedCarController;
    public int carCount = 5;

    public Text healthText;
    public Text winnerText;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();

        // get all cars with tag "carTag"
        GameObject[] carObjects = GameObject.FindGameObjectsWithTag("carTag");
        Debug.Log(carObjects[0].name);
        cars = new List<GameObject>(carObjects);

        NextCar();  // select the first car
    }

    // Update is called once per frame
    void Update()
    {
        selectedCarController.RotationPreview(sliderForce.value, -sliderAngle.value);

        // enter = big enter, return = small enter
        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Debug.Log("ENTER");
            BoostAction boost=selectedCarController.GetComponent<CarController>().boost;
            //string boost=selectedCarController.GetComponent<CarController>().boost;
            Debug.Log(boost);
            if(boost!=null)
            {
                Debug.Log("POUZITY BOOST: "+boost);
                selectedCarController.GetComponent<CarController>().boost.UseBoost();
            }
            else
            {
                Debug.Log("NEMAS");
            }
        }

        if (Input.GetKeyDown("space"))
        {

            if (sliderAngleController.isRunning)
            {
                sliderForceController.Continue();
                sliderAngleController.Pause();
            }
            else if (sliderForceController.isRunning)
            {
                sliderForceController.Pause();
                StartCoroutine(selectedCarController.MoveAnimate(this, sliderForce.value, -sliderAngle.value));
            }
            
        }
        UpdateGUI();
        HideDeadCars();
        CheckWinCondition();
    }

    private void CheckWinCondition() {
        // pause the game if only one car is left
        if (cars.Count == 1)
        {
            // get first carController
            GameObject winner = cars[0];

            // set winnerText to winning car
            winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().debugName + "</color> " + " won!";
            Time.timeScale = 0;
        }
        if (cars.Count == 0)
        {
            winnerText.text = "No one won!";
            Time.timeScale = 0;
        }
    }

    private void HideDeadCars() {
        // if any car health is below 0, hide it
        // TODO: properly destroy it
        for (int i = 0; i < cars.Count; i++)
        {
            GameObject car = cars[i];
            if (car.GetComponent<CarController>().health <= 0)
            {
                car.GetComponent<CarController>().HideCar();
                cars.Remove(car);
            }
        }
    }

    public void NextCar()
    {
        // if no cars in the list
        if (cars.Count == 0)
        {
            Debug.Log("No cars");
        }

        // switch control to the next car
        selectedCarIndex++;
        sliderAngleController.Continue();
        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        selectedCarController = cars[selectedCarIndex].GetComponent<CarController>();


    }


    private void UpdateGUI()
    {
        // update car health in gui
        string hText = "Health:\n";
        foreach (GameObject car in cars)
        {
            // get hex color of car and add it to <color> tag
            hText += "<color=#" + ColorUtility.ToHtmlStringRGB(car.GetComponent<SpriteRenderer>().color) + ">" + car.GetComponent<CarController>().debugName + "</color> " + Mathf.Round(car.GetComponent<CarController>().health) + "\n";
        }
        healthText.text = hText + "";
    }
    
}
