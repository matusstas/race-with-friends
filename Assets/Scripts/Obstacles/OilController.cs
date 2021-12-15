using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other){
        Quaternion rotation=other.gameObject.transform.rotation;
        other.gameObject.transform.rotation=Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z+ Random.Range(-45f,45f));

    }

}
