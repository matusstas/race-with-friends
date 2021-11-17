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
    private int selectedCarIndex = 0;
    private CarController selectedCarController;
    public int carCount = 5;

    public Text healthText;
    public Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("carTag"));
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
        NextCar();  // select first car's controller
        GenerateNewCars(carCount - 1);  // then generate the rest of the cars
    }

    // Update is called once per frame
    void Update()
    {
        selectedCarController.RotationPreview(sliderForce.value, -sliderAngle.value);


         if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Debug.Log("ENTER");
            string boost=selectedCarController.GetComponent<CarController>().boost;
            Debug.Log(boost);
            if(boost!="")
            {
                Debug.Log("POUZITY BOOST: "+boost);
                selectedCarController.GetComponent<CarController>().UseBoost();
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
        // then switch control to the next car
        selectedCarIndex++;
        sliderAngleController.Continue();
        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        selectedCarController = cars[selectedCarIndex].GetComponent<CarController>();
    }

    private void GenerateNewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            GameObject car = Instantiate(cars[0], new Vector2(i, i), Quaternion.identity);
            car.tag = "carTag";

            // set car color to random color
            car.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cars.Add(car);
        }

        // update debugname for all cars
        foreach (GameObject car in cars)
        {
            car.GetComponent<CarController>().debugName = "Car" + cars.IndexOf(car);
        }
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
