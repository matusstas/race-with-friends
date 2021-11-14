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
    private int selectedCarIndex = 0;
    private GameObject selectedCar;
    public int carCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("carTag"));
        selectedCar = cars[0];
        
        
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
        NextCar();
        NewCars(carCount - 1);
    }

    // Update is called once per frame
    void Update()
    {
        selectedCar.GetComponent<CarController>().RotationPreview(sliderForce.value, -sliderAngle.value);

        if (Input.GetKey("up"))
        {
            selectedCar.GetComponent<CarController>().DebugMove(5f);
        }

        if (Input.GetKey("left"))
        {
            selectedCar.GetComponent<CarController>().DebugRotate(3f);
        }

        if (Input.GetKey("right"))
        {
            selectedCar.GetComponent<CarController>().DebugRotate(-3f);;
        }

        if (Input.GetKeyDown("space"))
        {

            if (sliderForceController.isRunning)
            {
                sliderForceController.Pause();
                //sliderAngleController.Continue();
                StartCoroutine(selectedCar.GetComponent<CarController>().MoveAnimate(this, sliderForce.value, -sliderAngle.value));
                //NextCar();
            }
            else
            {
                sliderForceController.Continue();
                sliderAngleController.Pause();
            }
        }
    }

    public void NextCar()
    {
        // switches control to the next car
        selectedCarIndex++;
        sliderAngleController.Continue();
        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        selectedCar = cars[selectedCarIndex];
    }

    private void NewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            GameObject car = Instantiate(cars[0], new Vector2(i, i), Quaternion.identity);
            car.tag = "carTag";
            cars.Add(car);
        }
    }
    
}
