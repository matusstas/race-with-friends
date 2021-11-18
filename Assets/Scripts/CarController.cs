using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    private GameObject carPreview;
    private Rigidbody2D carRb;
    private bool rotationPreview = false;
    private Quaternion initialRotation;
    private bool newCar=true;
    public GameObject boost;
    public float health=100;
    public string debugName; // car name for console logs

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotationPreview(float speed, float angle)
    {
        if (!rotationPreview && newCar) 
        {
            RotationPreviewStart();
        }

        else{
            transform.rotation=initialRotation;
            carRb.transform.Rotate(0, 0, angle);
        }

        if (newCar)
        {
            // save original car color
            GetComponent<SpriteRenderer>().color = new Color(1f, .5f - speed / 2, .5f - speed / 2);
        }
    }


    private void RotationPreviewStart()
    {
        Debug.Log("BOOST: "+boost);
        initialRotation=transform.rotation;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rotationPreview = true;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void RotationPreviewEnd()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
        rotationPreview = false;
        newCar=false;

        // restore original car color 
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    // car move animation coroutine
    public IEnumerator MoveAnimate(KeyboardController keycontroll, float duration, float angle)
    {
        // ends preview, moves car to new position and rotates it to new angle at the same time
        RotationPreviewEnd();

        // move forward
        float time = 0.0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            carRb.AddForce(transform.up * 50);
            yield return null;
        }

        // wait till car stops
        // if we don't do it, current car would not collide with the next car
        while (carRb.velocity.magnitude > 0.1f)
        {
            yield return null;
        }

        newCar=true;
        keycontroll.NextCar();

    }

    public void UseBoost(){
        Debug.Log("POUZIVAM "+boost);
        boost=null;
    }

    // on colision with other car decrease health based on speed
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "carTag")
        {
            float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            health -= speed * 10;
        }
    }

    // hide car
    public void HideCar()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
