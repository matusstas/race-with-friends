using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("TCar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<SCar>().Move();
            }
            
        }

        if (Input.GetKey("left"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<SCar>().Rotate(3);
            }
        }

        if (Input.GetKey("right"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<SCar>().Rotate(-3);
            }
        }
    }
}
