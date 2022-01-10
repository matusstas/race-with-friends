using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceWinCondition : MonoBehaviour
{
    public CarsController carsController;
    public GuiController guiController;
 
    // Start is called before the first frame update
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

    void CheckWinCondition(GameObject carToBeDestroyed)
    {
        int carCount = carsController.cars.Count;
        int originalCarCount = PlayerPrefs.GetInt("numberOfPlayers", 2);
        if (originalCarCount - carCount == 1)
        {
            GameObject winner = carToBeDestroyed;
            //winnerText.text = "<color=#" + ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color) + ">" + winner.GetComponent<CarController>().name + "</color> " + " won!";
            //string carColor = ColorUtility.ToHtmlStringRGB(winner.GetComponent<SpriteRenderer>().color);
            string carName = winner.GetComponent<CarController>().name;

            //carsController.results.Add(ColorizeCar(winner,carName));
        }
        if (carCount == 1)
        {
            string carName=carsController.cars[0].GetComponent<CarController>().name;
            carsController.results.Add(ColorizeCar(carsController.cars[0],carName));
            guiController.ShowResults(carsController.results);
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
