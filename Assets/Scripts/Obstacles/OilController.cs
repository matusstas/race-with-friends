using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour
{
    // Obstacles will only be in race mode
    // their goal is to reduce the chances of winning
    
    private void OnTriggerEnter2D(Collider2D other){
        // When passing over the obstacle, the trajectory changes by a random angle from the range -45 to 45 degrees
        
        Debug.Log("Oil");
        Quaternion rotation=other.gameObject.transform.rotation;
        other.gameObject.transform.rotation=Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z+ Random.Range(-45f,45f));

    }

}
