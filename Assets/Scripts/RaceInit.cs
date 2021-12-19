using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceInit : MonoBehaviour
{
    private int carCount;
    public GameObject carTemplate;
    public GameObject carNumberTemplate;

    private GameObject start;

    public GameObject[] levels;


    void Awake()
    {
        carCount = PlayerPrefs.GetInt("numberOfPlayers", 2);
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
        Color[] colors = {Color.red, Color.green, Color.blue, Color.cyan, Color.gray, Color.magenta, Color.yellow, Color.white, Color.black, Color.gray};

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
            carNumberTemplate.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            GameObject newCarNumber = Instantiate(carNumberTemplate, startCarPosition, startRotation);
            newCarNumber.tag = "CarNumber";
            newCarNumber.GetComponent<TextMesh>().text = i.ToString();

            // create new car
            carTemplate.transform.localScale = new Vector3(0.18f, 0.18f, 1);
            GameObject newCar = Instantiate(carTemplate, startCarPosition, startRotation);
            
            newCar.tag = "Car";
            newCar.GetComponent<CarController>().name = Global.carNames[i];
            newCar.GetComponent<CarController>().carNumberTemplate = newCarNumber;
            
            
            newCar.GetComponent<SpriteRenderer>().color = colors[i];
        }

        Debug.Log("Generated " + count + " cars");
    }
}
