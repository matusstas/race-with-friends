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


    private GameObject controlls;
    public Text healthText;
    public Text winnerText;

    public Text resultsText;
    public GameObject resultsPanel;

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
        GlobalEvents.CarTurnEnd.AddListener(ShowBoost);
        

        // back button
        backBtn.onClick.AddListener(BackBtnClick);
    }

    // onDestroy unsubscribe from events
    void OnDestroy()
    {
        // remove listener
        GlobalEvents.CarStateChanged.RemoveListener(CarStateChanged);
        GlobalEvents.CarTurnEnd.RemoveListener(ShowBoost);

    }


    // Start is called before the first frame update
    void Start()
    {
        CarController selectedCar = carsController.selectedCar.GetComponent<CarController>();
        if (selectedCar.boost){
            boost=(GameObject)Instantiate(selectedCar.boost.gameObject, new Vector3(8,-4,0), Quaternion.identity);
            
        }
        controlls=GameObject.FindGameObjectWithTag("Controlls");
        controlls.SetActive(false);
        resultsPanel.SetActive(false);
        Debug.Log("Results",resultsPanel);
    }

    // Update is called once per frame
    void Update()
    {
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
        string hText = "";
        foreach (GameObject car in carsController.cars)
        {
            if (car != null)
            {
                string carColor = ColorUtility.ToHtmlStringRGB(car.GetComponent<SpriteRenderer>().color);
                string carName = car.GetComponent<CarController>().name;
                float carHealth = Mathf.Round(car.GetComponent<CarController>().health);

                if (PlayerPrefs.GetString("gameMode") == "race")
                {
                    hText += "<color=#" + carColor + ">" + carName + "</color>\n";
                } else
                {
                    hText += "<color=#" + carColor + ">" + carName + "</color>: " + carHealth + "hp\n";
                }
            }
        }
        healthText.text = hText;
    }

    private void ShowBoost()
    {
        Debug.Log("BOOST");
        
        Destroy(boost);
        CarController selectedCar = carsController.selectedCar.GetComponent<CarController>();
        Debug.Log(selectedCar.boost);
        if (selectedCar.boost){
            boost=(GameObject)Instantiate(selectedCar.boost.gameObject, new Vector3(7.5f,-4,0), Quaternion.identity);
            boost.active=true;
        }
    }

    public void HideBoost()
    {
        Destroy(boost);
    }

    private void BackBtnClick()
    {
        if (PlayerPrefs.GetString("gameMode") == "race")
        {
            SceneManager.LoadScene("RaceScene");   
        } else
        {
            SceneManager.LoadScene("NamePlayersScene");
        }
    }


    public void ShowControlls()
    {
        if (controlls.activeSelf==true)
            {
                controlls.SetActive(false);
            }
        else
        {
            controlls.SetActive(true);
        }
    }

    public void ShowResults(List<string> results)
    {
        resultsPanel.SetActive(true);
        //resultsPanel.GetComponent<Image>().color=Color.red;
        resultsText.text="Results: \n";
        for(int i=0; i<results.Count; i++)
        {
            resultsText.text+=(i+1)+". place: "+results[i]+"\n";
        }
    }

    public void ShowResultsOther(string text)
    {
        resultsPanel.SetActive(true);
        //resultsPanel.GetComponent<Image>().color=Color.red;
        resultsText.text="Results: \n"+text;

    }

}
