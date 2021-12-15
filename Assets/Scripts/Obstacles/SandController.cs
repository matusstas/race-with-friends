using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandController : MonoBehaviour
{
    
    Collider2D other;
    float force;
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("SAND");
        this.other=other;
        force=other.gameObject.GetComponent<CarController>().force;
        other.gameObject.GetComponent<CarController>().force/=5;
        other.gameObject.GetComponent<Rigidbody2D>().velocity/=2f;
        GlobalEvents.CarTurnEnd.AddListener(RestoreForce);

    }

    private void RestoreForce(){
        other.gameObject.GetComponent<CarController>().force=force;
        GlobalEvents.CarTurnEnd.RemoveListener(RestoreForce);
    }

}
