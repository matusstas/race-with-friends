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

        // gameObject.transform.position.z = -1f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2);

        // copy current gameObject
        GameObject copy = Instantiate(gameObject);
        // GameObject copy = Instantiate(gameObject, transform);
        copy.transform.SetParent(gameObject.transform.parent);
        copy.transform.position = new Vector3(copy.transform.position.x, copy.transform.position.y, -1);

        // detach this script
        Destroy(gameObject.GetComponent<CopyObject>());
    }
}