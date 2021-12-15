using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutodromInit : MonoBehaviour
{
    private int carCount;

    public GameObject carTemplate;


    void Awake()
    {
        carCount = PlayerPrefs.GetInt("numberOfPlayers");
        if (carCount < 1)
        {
            Debug.LogError("carCount has to be greater than 0");
        }
        GenerateNewCars(carCount);  // then generate the rest of the cars

        // add "SelectedCar" tag to the first car
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


    private void GenerateNewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            // get random 2d position that isn't too close to other objects
            Vector2 randomPosition = Helpers.GetRandomPosition(2f);
            
            // random rotation
            float randomRotation = Random.Range(0, 360);

            // create new car
            GameObject newCar = Instantiate(carTemplate, randomPosition, Quaternion.Euler(0, 0, randomRotation));

            newCar.tag = "Car";
            newCar.GetComponent<CarController>().name = "Car" + i;
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
