using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject prefabCar;
    public int nCars = 2;

    // Start is called before the first frame update
    void Start()
    {

        // instantiate n car objects from carPrefab
        // Comment this scope to disable generating car objects
        for (int i = 0; i < nCars; i++) 
        {
            GameObject car = Instantiate(prefabCar, new Vector2(i, i), Quaternion.identity);
            car.tag = "carTag";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
