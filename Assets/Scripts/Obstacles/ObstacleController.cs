using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleController : MonoBehaviour
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
        Debug.Log("Obstacle trigger");
        gameObject.GetComponent<ObstacleAction>().UseObstacle();

        // Debug.Log("ZOBRATY BOOST");
        // Debug.Log(other.GetComponent<CarController>().name);
        // other.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        // other.GetComponent<CarController>().boost = gameObject.GetComponent<BoostAction>();
        // Debug.Log(other.GetComponent<CarController>().boost);
        // Debug.Log(gameObject.name);
        // gameObject.SetActive(false);
    }
}
