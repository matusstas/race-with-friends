using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    private GameObject carPreview;
    private Rigidbody2D carRb;
    private bool rotationPreview = false;

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
        if (!rotationPreview)
        {
            RotationPreviewStart();
        }
        carPreview.transform.position = transform.position;
        carPreview.transform.rotation = transform.rotation;
        carPreview.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, angle);

        // red color based on speed, higher speed = more red
        carPreview.GetComponent<SpriteRenderer>().color = new Color(1f, .5f - speed / 2, .5f - speed / 2);
    }


    private void RotationPreviewStart()
    {
        // create preview car without colider and with red color
        carPreview = Instantiate(gameObject, transform.position, transform.rotation);
        carPreview.GetComponent<CapsuleCollider2D>().enabled = false;
        rotationPreview = true;
    }

    public void RotationPreviewEnd()
    {
        // destroys rotation preview
        rotationPreview = false;
        Destroy(carPreview);
    }

    // rotation coroutine
    public IEnumerator MoveAnimate(float duration, float angle)
    {
        // ends preview, moves car to new position and rotates it to new angle at the same time
        RotationPreviewEnd();

        float time = 0.0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            carRb.transform.Rotate(0, 0, angle * Time.deltaTime / duration);
            carRb.AddForce(transform.up * 5);
            yield return null;
        }
    }

    public void DebugMove(float thrust)
    {
        // debug use only
        carRb.AddForce(transform.up * thrust);
    }

    public void DebugRotate(float angle)
    {
        // debug use only
        carRb.transform.Rotate(0, 0, angle);
    }
}
