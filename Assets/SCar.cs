using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCar : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float thrust = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        rb2D.AddForce(transform.up * thrust);
    }

    public void Rotate(int n)
    {
        rb2D.transform.Rotate(0, 0, n);
        // rb2D.AddForce(rotate.left * thrust);
    }
}
