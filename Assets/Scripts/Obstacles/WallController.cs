using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Obstacles will only be in race mode
    // their goal is to reduce the chances of winning

    private void OnTriggerEnter2D(Collider2D other){
        // The car does not pass a solid obstacle, it crashes into it.
        // However, when the bounce boost is ON, it bounces off.

        Debug.Log("Wall");
    }
}
