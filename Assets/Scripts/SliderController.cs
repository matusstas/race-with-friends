using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public int direction = 1;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(slider.value);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            // Debug.Log(direction);
            if (slider.value > 0.99f)
            {
                direction = -1;
            }

            if (slider.value < 0.01f)
            {
                direction = 1;
            }

            slider.value += direction * 0.01f;
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
