using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static Vector2 GetRandomPosition(float circleCistance)
    {
        // generate random 2d position that is not close to the other objects
        Vector2 position = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
        while (Physics2D.OverlapCircle(position, circleCistance))
        {
            position = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
            circleCistance -= 0.01f;  // fallback if there is nowhere to place the object in the chosen distance
        }
        return position;
    }

    public static GameObject GetGameObjectUnderMouse2D()
    {
        var mainCamera = Camera.main;
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("GameObjectUnderMouse2D: " + hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }
        Debug.Log("GameObjectUnderMouse2D: " + null);
        return null;
    }

}
