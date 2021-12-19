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
                    hText += carName + "\n";
                } else
                {
                    hText += "<color=#" + carColor + ">" + carName + "</color>: " + carHealth + "hp\n";
                }
            }
        }
        healthText.text = hText;
    }


    private void CheckWinCondition(GameObject carToBeDestroyed)
    {
        int carCount = carsController.cars.Count;
        if (PlayerPrefs.GetString("gameMode")=="autodrom")
        {

            if(PlayerPrefs.GetString("mode")=="all")
            {
                // pause the game if only one car is left
                if (carCount == 1)
                {
                    // get first carController
                    GameObject winner = carsController.cars[0];

                    // set winnerText to winning car
                    winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().name + "</color> " + " won!";
                    //Time.timeScale = 0;
                    carsController.results.Add((string)carsController.cars[0].name);
                    carsController.results.Reverse();
                    ShowResults(carsController.results);
                }

                // or if no one is left
                if (carCount == 0)
                {
                    winnerText.text = "No one won!";
                    //Time.timeScale = 0;

                    //ShowResults();
                }
            }

            else
            {
                bool oneTeam=true;
                int teamNum=-1;
                foreach(GameObject car in carsController.cars)
                {
                    int num=car.GetComponent<CarController>().teamId;
                    if (teamNum==-1)
                        teamNum=num;
                    if (num!=teamNum)
                    {
                        oneTeam=false;
                        break;
                    }
                }
                if (oneTeam)
                {
                    GameObject winner = carsController.cars[0];
                    winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + "> Team" + winner.GetComponent<CarController>().teamId + "</color> " + " won!";
                    //TODO obrazovka ktory team vyhral
                    //ShowResults();
                }

            }
        } else 
        {
            int originalCarCount = PlayerPrefs.GetInt("numberOfPlayers", 2);
            if (originalCarCount - carCount == 1)
            {
                GameObject winner = carToBeDestroyed;
                winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().name + "</color> " + " won!";
                
            }
            if (carCount == 1)
            {
                carsController.results.Add((string)carsController.cars[0].name);
                ShowResults(carsController.results);
            }
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

    private void ShowResults(List<string> results)
    {
        resultsPanel.SetActive(true);
        //resultsPanel.GetComponent<Image>().color=Color.red;
        resultsText.text="Results: \n";
        for(int i=0; i<results.Count; i++)
        {
            resultsText.text+=(i+1)+". place: "+results[i]+"\n";
        }
    }
}
