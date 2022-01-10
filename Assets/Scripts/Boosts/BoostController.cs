using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoostController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Boost");
        Debug.Log(other.GetComponent<CarController>().name);

        other.GetComponent<CarController>().boost = gameObject.GetComponent<BoostAction>();
        
        Debug.Log(other.GetComponent<CarController>().boost);
        Debug.Log(gameObject.name);

        // trigger BoostPickedUp event
        GlobalEvents.BoostPickedUp.Invoke();
    }
}
