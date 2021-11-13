using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderController : MonoBehaviour
{
    public Slider slider;
    public bool isRunning = true;
    public float minValue = 0f;
    public float maxValue = 1f;
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
            if (slider.value > maxValue-speed)
            {
                direction *= -1;
            }

            if (slider.value < minValue+speed)
            {
                direction *= -1;
            }

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
