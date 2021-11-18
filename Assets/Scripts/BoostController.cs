using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("ZOBRATY BOOST");
        Debug.Log(other.name);
        other.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        other.GetComponent<CarController>().boost = gameObject;
        Destroy(gameObject);
    }
}
