using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float thrust)
    {
        rb2D.AddForce(transform.up * thrust);
    }

    public void Rotate(float angle)
    {
        rb2D.transform.Rotate(0, 0, angle);
        // rb2D.AddForce(rotate.left * thrust);
    }
}
