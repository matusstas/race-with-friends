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
    private CarController selectedCarController;
    public int carCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("carTag"));
        sliderForceController = sliderForce.GetComponent<SliderForceController>();
        sliderAngleController = sliderAngle.GetComponent<SliderAngleController>();
        NextCar();  // select first car's controller
        GenerateNewCars(carCount - 1);  // then generate the rest of the cars
    }

    // Update is called once per frame
    void Update()
    {
        selectedCarController.RotationPreview(sliderForce.value, -sliderAngle.value);

        if (Input.GetKeyDown("space"))
        {

            if (sliderAngleController.isRunning)
            {
                sliderForceController.Continue();
                sliderAngleController.Pause();
            }
            else if (sliderForceController.isRunning)
            {
                sliderForceController.Pause();
                StartCoroutine(selectedCarController.MoveAnimate(this, sliderForce.value, -sliderAngle.value));
            }
            
        }

        // if (Input.GetKey("up"))
        // {
        //     selectedCarController.DebugMove(5f);
        // }

        // if (Input.GetKey("left"))
        // {
        //     selectedCarController.DebugRotate(3f);
        // }

        // if (Input.GetKey("right"))
        // {
        //     selectedCarController.DebugRotate(-3f);;
        // }
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
        selectedCarController = cars[selectedCarIndex].GetComponent<CarController>();
    }

    private void GenerateNewCars(int count)
    {
        // creates new car objects, count is the number of cars to create
        for (int i = 0; i < count; i++)
        {
            GameObject car = Instantiate(cars[0], new Vector2(i, i), Quaternion.identity);
            car.tag = "carTag";

            // set car color to random color
            car.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            cars.Add(car);
        }
    }
    
}
