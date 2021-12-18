using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceInit : MonoBehaviour
{
    private int carCount;
    public GameObject carTemplate;
    public GameObject carNumberTemplate;

    private GameObject start;

    public GameObject[] levels;


    void Awake()
    {
        carCount = PlayerPrefs.GetInt("numberOfPlayers");
        // Debug.Log("NC: " + carCount);
        // Debug.Log("NCtype: " + carCount.GetType());

        int levelNumber = PlayerPrefs.GetInt("level");
        if (levelNumber != 0)
        {
            Instantiate(levels[levelNumber-1]);
        }
        
        // Debug.Log(GameObject.FindGameObjectWithTag("Level"));

        //get startline prefab
        start=GameObject.FindGameObjectWithTag("Start");
       
        GenerateNewCars(carCount);  // then generate the rest of the cars

        Debug.Log("XXX");
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
            //Vector2 randomPosition = Helpers.GetRandomPosition(2f);

            Vector3 startCarPosition=start.transform.position;  

            //
            startCarPosition.y-=carTemplate.transform.localScale.x*2;  
            startCarPosition.z=-1;
                    
            // random rotation
            Quaternion startRotation = start.transform.rotation;

            // create new car number
            carNumberTemplate.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            GameObject newCarNumber = Instantiate(carNumberTemplate, startCarPosition, startRotation);
            newCarNumber.tag = "CarNumber";
            newCarNumber.GetComponent<TextMesh>().text = i.ToString();

            // create new car
            GameObject newCar = Instantiate(carTemplate, startCarPosition, startRotation);
            
            newCar.tag = "Car";
            newCar.GetComponent<CarController>().name = "Car" + i;
            newCar.GetComponent<CarController>().carNumberTemplate = newCarNumber;
            
            
            // set car color to random color
            newCar.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        Debug.Log("Generated " + count + " cars");
    }




}
