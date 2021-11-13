using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float rotationOffset = 0.0f;

    private GameObject carClone;

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

    public void RotationPreview(float angle)
    {
        // set carClone position to car position
        carClone.transform.position = transform.position;

        // set carClone rotation to car rotation
        

        // show carClone
        carClone.SetActive(true);

        // turn off colider

        float newAngle = angle - rotationOffset;
        carClone.transform.rotation = transform.rotation;
        carClone.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, angle);
        rotationOffset = rotationOffset + newAngle;
    }

    public void RotationPreviewEnd()
    {
        carClone.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, -rotationOffset);
        
        // hide carClone
        carClone.SetActive(false);

        // deinstantiate carClone
        Destroy(carClone);
    }
    public void RotationPreviewStart()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        carClone = Instantiate(gameObject, transform.position, transform.rotation);
        GetComponent<CapsuleCollider2D>().enabled = true;
        carClone.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f);  // set current car color to red
    }

    // rotation coroutine
    public IEnumerator MoveAnimate(float duration, float angle)
    {
        float t = 0.0f;
        while ( t  < duration )
        {
            Debug.Log(t);
            t += Time.deltaTime;
            rb2D.transform.Rotate(0, 0, angle * Time.deltaTime / duration);
            rb2D.AddForce(transform.up * 5);
            yield return null;
        }
    }
}
