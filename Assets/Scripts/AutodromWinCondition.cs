using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutodromWinCondition : MonoBehaviour
{
    public CarsController carsController;
    public GuiController guiController;
    void Start()
    {
        GlobalEvents.CarDestroyed.AddListener(CheckWinCondition);

    }

    void OnDestroy()
    {
        // remove listener
        GlobalEvents.CarDestroyed.RemoveListener(CheckWinCondition);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckWinCondition(GameObject carToBeDestroyed)
    {


        if (PlayerPrefs.GetString("mode") == "all")
        {
            WinConditionAll();
        }

        else
        {
            WinConditionTeam();
        }
    }

    private void WinConditionAll()
    {
        // pause the game if only one car is left
        int carCount = carsController.cars.Count;
        if (carCount == 1)
        {
            // get first carController
            GameObject winner = carsController.cars[0];

            //string carColor = ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color);
            string carName = winner.GetComponent<CarController>().name;

            carsController.results.Add(ColorizeCar(winner,carName));

            carsController.results.Reverse();
            guiController.ShowResults(carsController.results);
        }

        // or if no one is left
        if (carCount == 0)
        {
           guiController.ShowResultsOther("No one won!!\n(both cars died in last crash)");
        }
    }


    private void WinConditionTeam()
    {
        int carCount = carsController.cars.Count;
        bool oneTeam = true;
        int teamNum = -1;

        if (carCount == 0)
        {
            
            guiController.ShowResultsOther("No one won!!\n(both cars died in last crash)");
        }

        else
        {
            foreach (GameObject car in carsController.cars)
            {
                int num = car.GetComponent<CarController>().teamId;
                if (teamNum == -1)
                    teamNum = num;
                if (num != teamNum)
                {
                    oneTeam = false;
                    break;
                }
            }
            if (oneTeam)
            {
                GameObject winner = carsController.cars[0];
                //winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + "> Team" + winner.GetComponent<CarController>().teamId + "</color> " + " won!";
                //TODO obrazovka ktory team vyhral
                guiController.ShowResultsOther(ColorizeCar(winner,"Team "+teamNum)+" won!!");
            }
        }
    }


    public string ColorizeCar(GameObject car, string text)
    {
        string carColor = ColorUtility.ToHtmlStringRGB(car.GetComponent<SpriteRenderer>().color);
        string carName = car.GetComponent<CarController>().name;
        float carHealth = Mathf.Round(car.GetComponent<CarController>().health);
        return "<color=#" + carColor + ">" + text + "</color>";
    }

}
