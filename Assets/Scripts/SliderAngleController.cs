using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAngleController : MonoBehaviour
{
    public Slider slider;
    public int direction = 1;
    public bool paused = false;

    public float force = 2f;

    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            // Debug.Log(direction);
            if (slider.value > 89f)
            {
                direction = -1;
            }

            if (slider.value < -89f)
            {
                direction = 1;
            }

            slider.value += direction * force;
        }
    }
    public void Pause()
    {
        paused = true;
    }

    public void Continue()
    {
        paused = false;
    }
}
