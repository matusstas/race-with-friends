using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum CarState
{
    NOT_SELECTED,
    SELECTING_ANGLE,
    SELECTING_SPEED,
    ANIMATING
}

public class CarController : MonoBehaviour
{
    private Rigidbody2D carRb;
    private RotationPreview rotationPreview;
    private ColorPreview colorPreview;

    public BoostAction boost = null;
    public float health = 100;

    public CarState carState;
    public bool isCollidingWithWall = false;
    public float previewForce = 0;
    public float previewAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detroy car if health is 0
        if (health <= 0)
        {
            GlobalEvents.CarDestroyed.Invoke(gameObject);
            Destroy(gameObject);
        }
        if (carState == CarState.SELECTING_ANGLE)
        {
            rotationPreview.UpdatePreview(previewAngle);
        }
        else if (carState == CarState.SELECTING_SPEED)
        {
            colorPreview.UpdatePreview(new Color(1f, .5f - previewForce / 2, .5f - previewForce / 2));
            // Debug.Log(name + " previewForce " + previewForce);
            // Debug.Log(name + " previewAngle " + previewAngle);
        }
        else if (carState == CarState.ANIMATING)
        {
            // wait for animation to finish
        }
    }

    public void NextState()
    {
        CarState previousState = carState;

        if (carState == CarState.NOT_SELECTED)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            rotationPreview = new RotationPreview(this);
            colorPreview = new ColorPreview(this);
            carState = CarState.SELECTING_ANGLE;
        }
        else if (carState == CarState.SELECTING_ANGLE)
        {
            gameObject.GetComponent<Rigidbody2D>().mass = 1;
            gameObject.GetComponent<Rigidbody2D>().drag = 2;
            carState = CarState.SELECTING_SPEED;
        }
        else if (carState == CarState.SELECTING_SPEED)
        {

            GetComponent<CapsuleCollider2D>().enabled = true;
            colorPreview.ResetPreview();

            colorPreview = null;
            rotationPreview = null;

            Debug.Log(name + " previewForce " + previewForce);
            Debug.Log(name + " previewAngle " + previewAngle);

            carState = CarState.ANIMATING;
            StartCoroutine(MoveAnimate());  // coroutine will change the state to NOT_SELECTED after animation is done
        }
        Debug.Log(name + " carState" + carState);

        // if state has changed, send UnityEvent carStateChanged
        if (previousState != carState)
        {
            GlobalEvents.CarStateChanged.Invoke(carState);
        }
    }

    // car move animation coroutine
    public IEnumerator MoveAnimate()
    {
        // move forward
        float time = 0.0f;
        float direction = previewForce > 0 ? 1f : -1f;
        previewForce = Mathf.Abs(previewForce);

        // wait for automatic collision logic to move car outside of the collision
        yield return null;
        yield return null;
        yield return null;
        isCollidingWithWall = false; // pretend that collision isn't happening even if it is

        while (time < previewForce)
        {
            time += Time.deltaTime;

            if (!isCollidingWithWall)
            {
                carRb.AddForce(transform.up * 50 * direction);
            }
            else   // if is colliding again, stop the car
            {

                carRb.velocity = Vector2.zero;
                carRb.isKinematic = true;
                carRb.angularVelocity = 0;
                yield return null;  // wait one frame
                carRb.isKinematic = false;
                break;
            }

            yield return null;
        }

        // wait till car stops
        // if we don't do it, current car would not collide with the next car
        while (carRb.velocity.magnitude > 0.1f)
        {
            if (isCollidingWithWall)
            {
                carRb.velocity = Vector2.zero;
                carRb.isKinematic = true;
                carRb.angularVelocity = 0;
                yield return null;  // wait one frame
                carRb.isKinematic = false;
            }
            yield return null;
        }

        // reset previewForce and previewAngle back to zero
        previewForce = 0;
        previewAngle = 0;

        carState = CarState.NOT_SELECTED;
        GlobalEvents.CarStateChanged.Invoke(carState);
        GlobalEvents.CarTurnEnd.Invoke();
    }

    public void UseBoost()
    {
        Debug.Log("POUZIVAM " + boost);
        boost = null;
    }

    public void Finish()
    {
        Debug.Log("SOM V CILI");
        GlobalEvents.CarDestroyed.Invoke(gameObject);
        Destroy(gameObject);
    }

    // on colision with other car decrease health based on speed
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            float speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            health -= speed * 10;
        }
    }
}
