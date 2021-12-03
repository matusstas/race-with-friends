using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPreview
{
    private MonoBehaviour monoBehaviour;
    private Color originalColor;

 // constructor with original rotation
    public ColorPreview(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        originalColor = this.monoBehaviour.GetComponent<SpriteRenderer>().color;
    }

    public void UpdatePreview(Color previewColor)
    {
        monoBehaviour.GetComponent<SpriteRenderer>().color = previewColor;
    }

    public void ResetPreview()
    {
        monoBehaviour.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
