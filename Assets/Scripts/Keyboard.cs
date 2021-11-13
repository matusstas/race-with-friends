using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keyboard : MonoBehaviour
{
    public List<GameObject> cars;
    public Slider slider;
    public SliderController sliderController;
    public Slider sliderAngle;

    public SliderAngleController sliderAngleController;

    public float trust = 1000; 

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>(GameObject.FindGameObjectsWithTag("TCar"));
        sliderController = slider.GetComponent<SliderController>();
        sliderAngleController = slider.GetComponent<SliderAngleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            foreach (GameObject car in cars)
            {
                car.GetComponent<SCar>().Move(5f);
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

        if (Input.GetKeyDown("space"))
        {
            // Debug.Log(slider.value);
            if (sliderController.paused) {
                sliderController.Continue();
            }
            else
            {
                sliderController.Pause();
                cars[0].GetComponent<SCar>().Move(sliderController.slider.value * trust);
            }
        }
    }
}
