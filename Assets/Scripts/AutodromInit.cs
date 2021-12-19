using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutodromInit : MonoBehaviour
{
    private int carCount;

    public GameObject carTemplate;
    public GameObject carNumberTemplate;

    public GameObject[] boostsAndObstacles;

    void Awake()
    {
        carCount = PlayerPrefs.GetInt("numberOfPlayers");
        GenerateNewBoostsAndObstacles(10);
        GenerateNewCars(carCount);  // then generate the rest of the cars

        GameObject firstCar = GameObject.FindGameObjectsWithTag("Car")[0];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    private void GenerateNewBoostsAndObstacles(int count)
    {
        // creates new boost and obstacke objects, count is the number of boosts and obstacles to create
        for (int i = 0; i < count; i++)
        {
            // get random 2d position that isn't too close to other objects
            Vector2 randomPosition = Helpers.GetRandomPosition(2f);

            float rotation = 0; // in degrees

            // create new boost
            GameObject newBoost = Instantiate(boostsAndObstacles[Random.Range(0, boostsAndObstacles.Length)], randomPosition, Quaternion.Euler(0, 0, rotation));
            newBoost.tag = "Boost";
        }

        Debug.Log("Generated " + count + " boosts or obstacles");
    }


    private void GenerateNewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            // get random 2d position that isn't too close to other objects
            Vector2 randomPosition = Helpers.GetRandomPosition(2f);

            // random rotation
            float randomRotation = Random.Range(0, 360);


            // create new car number
            GameObject newCarNumber = Instantiate(carNumberTemplate, randomPosition, Quaternion.Euler(0, 0, randomRotation));
            newCarNumber.tag = "CarNumber";
            newCarNumber.GetComponent<TextMesh>().text = i.ToString();

            // create new car
            carTemplate.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            GameObject newCar = Instantiate(carTemplate, randomPosition, Quaternion.Euler(0, 0, randomRotation));

            newCar.tag = "Car";
            // Debug.Log("CAR NAME: " + inputFields[i]);
            // newCar.GetComponent<CarController>().name = "Car" + i;
            newCar.GetComponent<CarController>().name = Global.carNames[i];
            newCar.GetComponent<CarController>().carNumberTemplate = newCarNumber;

            //set mode
            string mode=PlayerPrefs.GetString("mode");
            if(mode=="all")
            {
                newCar.GetComponent<CarController>().teamId = i;
                newCar.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
                
            else
            {
                newCar.GetComponent<CarController>().teamId = i%2;
                newCar.GetComponent<SpriteRenderer>().color = new Color(i%2,0,1);
            }

            // set car color to random color
            
        }

        Debug.Log("Generated " + count + " cars");
    }

}
