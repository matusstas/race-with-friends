using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutodromInit : MonoBehaviour
{
    public int carCount;

    public GameObject carTemplate;

    void Awake()
    {
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
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            // get random 2d position that isn't too close to other objects
            Vector2 randomPosition = GetRandomPosition(2f);

            // random rotation
            float randomRotation = Random.Range(0, 360);

            // create new car
            GameObject newCar = Instantiate(carTemplate, randomPosition, Quaternion.Euler(0, 0, randomRotation));

            newCar.tag = "carTag";
            newCar.GetComponent<CarController>().debugName = "Car" + i;

            // set car color to random color
            newCar.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        Debug.Log("Generated " + count + " cars");
    }


    private static Vector2 GetRandomPosition(float circleCistance)
    {
        // generate random 2d position that is not close to the other objects
        Vector2 position = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
        while (Physics2D.OverlapCircle(position, circleCistance))
        {
            position = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
            circleCistance -= 0.01f;  // fallback if there is nowhere to place the object in the chosen distance
        }
        return position;
    }

}
