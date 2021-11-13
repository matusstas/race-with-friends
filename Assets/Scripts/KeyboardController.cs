using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyboardController : MonoBehaviour
{
    public List<GameObject> cars;
    public Slider sliderForce;
    public Slider sliderAngle;
    private SliderForceController sliderForceController;
    private SliderAngleController sliderAngleController;
    public float thrustCoeficient = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("carTag"));
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<CarController>().Move(5f);
            }
            
        }

        if (Input.GetKey("left"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<CarController>().Rotate(3f);
            }
        }

        if (Input.GetKey("right"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<CarController>().Rotate(-3f);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Press A");
            Debug.Log("Press B");

            if (sliderForceController.isRunning)
            {
                sliderForceController.Pause();
                sliderAngleController.Continue();
                float thrust = sliderForce.value * thrustCoeficient;
                cars[0].GetComponent<CarController>().Rotate(-sliderAngle.value);
                cars[0].GetComponent<CarController>().Move(thrust);
            }
            else
            {
                sliderForceController.Continue();
                sliderAngleController.Pause();
            }
        }
    }
}
