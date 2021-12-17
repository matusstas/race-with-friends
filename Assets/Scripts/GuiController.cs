using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiController : MonoBehaviour
{
    public CarsController carsController;

    public Slider sliderForce;
    public Slider sliderAngle;
    private SliderController sliderForceController;
    private SliderController sliderAngleController;


    public Text healthText;
    public Text winnerText;

    public Button backBtn;
    private GameObject boost;

    // subscribe to events
    void Awake()
    {
        sliderAngleController = sliderAngle.GetComponent<SliderController>();
        sliderForceController = sliderForce.GetComponent<SliderController>();
        sliderAngle.interactable = false;
        sliderForce.interactable = false;

        // add listener
        GlobalEvents.CarStateChanged.AddListener(CarStateChanged);
        GlobalEvents.CarDestroyed.AddListener(CheckWinCondition);
        GlobalEvents.CarTurnEnd.AddListener(ShowBoost);
        

        // back button
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // onDestroy unsubscribe from events
    void OnDestroy()
    {
        // remove listener
        GlobalEvents.CarStateChanged.RemoveListener(CarStateChanged);
        GlobalEvents.CarDestroyed.RemoveListener(CheckWinCondition);
        GlobalEvents.CarTurnEnd.RemoveListener(ShowBoost);

    }


    // Start is called before the first frame update
    void Start()
    {
        CarController selectedCar = carsController.selectedCar.GetComponent<CarController>();
        if (selectedCar.boost){
            boost=(GameObject)Instantiate(selectedCar.boost.gameObject, new Vector3(8,-4,0), Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("gameMode")=="autodrom") {
            UpdateCarHealthGUI();
        }
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

    private void CarStateChanged(CarState carState)
    {
        UpdateSlidersGUI();
        if (carState == CarState.SELECTING_ANGLE)  // at the start it is null
        {

            sliderForceController.Pause();
            sliderAngleController.Continue();
        }
        else if (carState == CarState.SELECTING_SPEED)
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


    private void CheckWinCondition(GameObject carToBeDestroyed)
    {
        int carCount = carsController.cars.Count;
        // pause the game if only one car is left
        if (carCount == 1)
        {
            // get first carController
            GameObject winner = carsController.cars[0];

            // set winnerText to winning car
            winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().name + "</color> " + " won!";
            //Time.timeScale = 0;
        }

        // or if no one is left
        if (carCount == 0)
        {
            winnerText.text = "No one won!";
            //Time.timeScale = 0;
        }
    }

    private void ShowBoost()
    {
        Debug.Log("BOOST");
        
        Destroy(boost);
        CarController selectedCar = carsController.selectedCar.GetComponent<CarController>();
        Debug.Log(selectedCar.boost);
        if (selectedCar.boost){
            boost=(GameObject)Instantiate(selectedCar.boost.gameObject, new Vector3(8,-4,0), Quaternion.identity);
            boost.active=true;
        }
    }

    public void HideBoost()
    {
        Destroy(boost);
    }

    private void BackBtnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
