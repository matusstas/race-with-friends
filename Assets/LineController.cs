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
        if (car.gameObject.tag == "Car")
        {
            // set is coliding to true
            CarController carController = car.gameObject.GetComponent<CarController>();
            carController.isCollidingWithWall = true;

            // CarController carController = car.gameObject.GetComponent<CarController>();

            // // Rigidbody2D carRigidBody = car.gameObject.GetComponent<Rigidbody2D>();

            // //float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            // //health -= speed * 10;
            // Debug.Log("OnCollisionEnter2D - colliding:" + carController.isColliding);
            // if (!carController.isColliding)
            // {
            //     Debug.Log("OnCollisionEnter2D not yet colliding, stopping car");
            //     rigidbody.isKinematic = true;
            //     rigidbody.velocity = Vector2.zero;

            //     // car.gameObject.GetComponent<Rigidbody2D>().mass = 1000000;
            //     // car.gameObject.GetComponent<Rigidbody2D>().drag = 1000000;
            //     carController.isColliding = true;
            //     Debug.Log(carController.isColliding);
            // }
        }
    }

    private void OnCollisionExit2D(Collision2D car)
    {
        if (car.gameObject.tag == "Car")
        {
            // set is coliding to false
            CarController carController = car.gameObject.GetComponent<CarController>();
            carController.isCollidingWithWall = false;
        }
        // if (car.gameObject.tag == "Car" && car.gameObject.GetComponent<CapsuleCollider2D>().enabled == true)
        // {
        //     Debug.Log("OnCollisionExit2D colider disabled");
        //     //float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        //     //health -= speed * 10;
        //     car.gameObject.GetComponent<CarController>().isColliding = false;
        //     Debug.Log(car.gameObject.GetComponent<CarController>().isColliding);
        // }
        // else if (car.gameObject.tag == "Car")
        // {
        //     Debug.Log("OnCollisionExit2D colider disabled");
        // }
    }
}
