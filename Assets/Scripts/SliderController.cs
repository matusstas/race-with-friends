using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public bool isRunning = true;
    public float speed = 0.01f;
    public int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRunning)
        {
            // if slider reached its maximum value switch the direction (go down)
            if (slider.value >= slider.maxValue-speed)
            {
                direction *= -1;
            }

            // if slider reached its maximum value switch the direction (go up)
            if (slider.value <= slider.minValue+speed)
            {
                direction *= -1;
            }

            // increase value in actual direction (up / down)
            slider.value += speed * direction;
        }
    }

    public void Pause()
    {
        isRunning = false;
    }

    public void Continue()
    {
        isRunning = true;
    }

}
