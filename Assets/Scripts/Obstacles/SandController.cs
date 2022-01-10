using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandController : MonoBehaviour
{
    // Obstacles are only in race mode
    // their goal is to reduce the chances of winning
    
    Collider2D other;
    float force;
    private void OnTriggerEnter2D(Collider2D other){
        // When passing over the obstacle, the velocity of the car is reduced by half
        
        Debug.Log("Sand");
        this.other=other;
        force=other.gameObject.GetComponent<CarController>().force;
        other.gameObject.GetComponent<CarController>().force/=5;
        other.gameObject.GetComponent<Rigidbody2D>().velocity/=2f;
        GlobalEvents.CarTurnEnd.AddListener(RestoreForce);

    }

    private void RestoreForce(){
        // return values back to normal
        
        other.gameObject.GetComponent<CarController>().force=force;
        GlobalEvents.CarTurnEnd.RemoveListener(RestoreForce);
    }

}
