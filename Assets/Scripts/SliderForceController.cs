using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderForceController : MonoBehaviour
{
    public Slider sliderForce;
    public bool isRunning = true;
    public float minValue = 0f;
    public float maxValue = 1f;
    public float offset = 0.01f;
    public int direction = 1;
    public Slider sliderAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRunning)
        {
            if (sliderForce.value > maxValue-offset)
            {
                direction *= -1;
            }

            if (sliderForce.value < minValue+offset)
            {
                direction *= -1;
            }

            sliderForce.value += offset * direction;
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
