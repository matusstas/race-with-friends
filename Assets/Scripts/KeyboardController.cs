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
    private int currentCarIndex = 0;
    public int carCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("carTag"));
        newCars(carCount - 1);
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
        NextCar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            cars[currentCarIndex].GetComponent<CarController>().Move(5f);
            
        }

        if (Input.GetKey("left"))
        {
            cars[currentCarIndex].GetComponent<CarController>().Rotate(3f);
        }

        if (Input.GetKey("right"))
        {
            cars[currentCarIndex].GetComponent<CarController>().Rotate(-3f);;
        }

        if (Input.GetKeyDown("space"))
        {
            if (sliderForceController.isRunning)
            {
                sliderForceController.Pause();
                sliderAngleController.Continue();
                float thrust = sliderForce.value * thrustCoeficient;
                cars[currentCarIndex].GetComponent<CarController>().RotationPreviewEnd();
                StartCoroutine(cars[currentCarIndex].GetComponent<CarController>().MoveAnimate(sliderForce.value, -sliderAngle.value));
                NextCar();
            }
            else
            {
                sliderForceController.Continue();
                sliderAngleController.Pause();
            }
        }

        // rotation preview
        if (sliderAngleController.isRunning)
        {
            cars[currentCarIndex].GetComponent<CarController>().RotationPreview(-sliderAngle.value);
        }
    }

    private void NextCar()
    {
        foreach(GameObject car in cars)
        {
            car.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);  // reset color back
        }
        currentCarIndex++;
        if (currentCarIndex >= cars.Count)
        {
            currentCarIndex = 0;
        }
        Debug.Log("Current car index: " + currentCarIndex);
        Debug.Log("cars.Count " + cars.Count);
        cars[currentCarIndex].GetComponent<CarController>().RotationPreviewStart();
    }

    private void newCars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject car = Instantiate(cars[0], new Vector2(i, i), Quaternion.identity);
            car.tag = "carTag";
            cars.Add(car);
        }
    }
    
}
