using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D car)
    {
         Debug.Log("trigger vonku");
        if (car.gameObject.tag == "Car")
        {
            //float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            //health -= speed * 10;
            Debug.Log("trigger");
            Debug.Log(car.gameObject.GetComponent<CarController>().isColliding);
            if (!car.gameObject.GetComponent<CarController>().isColliding)
            {
                Debug.Log("STOP");
                car.gameObject.GetComponent<Rigidbody2D>().mass=1000000;
                car.gameObject.GetComponent<Rigidbody2D>().drag=1000000;
                car.gameObject.GetComponent<CarController>().isColliding=true;
                Debug.Log(car.gameObject.GetComponent<CarController>().isColliding);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D car)
    {
        Debug.Log("COLIDER");
        Debug.Log(car.gameObject.GetComponent<CapsuleCollider2D>().enabled);
        if (car.gameObject.tag == "Car" && car.gameObject.GetComponent<CapsuleCollider2D>().enabled == true)
        {
            //float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            //health -= speed * 10;
            Debug.Log("leave");
            car.gameObject.GetComponent<CarController>().isColliding=false;
            Debug.Log(car.gameObject.GetComponent<CarController>().isColliding);
        }
    }
}
