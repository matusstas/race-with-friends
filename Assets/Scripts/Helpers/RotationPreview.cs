using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPreview
{
    private MonoBehaviour monoBehaviour;
    private Quaternion originalRotation;
    private Rigidbody2D rb;

 // constructor with original rotation
    public RotationPreview(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour; 
        rb = monoBehaviour.GetComponent<Rigidbody2D>();
        originalRotation = monoBehaviour.transform.rotation;
    }

    public void UpdatePreview(float previewAngle)
    {
        ResetPreview();
        rb.transform.Rotate(0, 0, previewAngle);
    }

    private void ResetPreview()
    {
        monoBehaviour.transform.rotation = originalRotation;
    }

}
