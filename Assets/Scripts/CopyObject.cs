using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // notes
        // instancia game object + nastavenie rovnakej pozicie + znici sa
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2);

        // copy current gameobject
        GameObject copy = Instantiate(gameObject);
        copy.transform.SetParent(gameObject.transform.parent);
        copy.transform.position = new Vector3(copy.transform.position.x, copy.transform.position.y, -1);

        // detach script on the gameobject
        Destroy(gameObject.GetComponent<CopyObject>());
    }
}