using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : ObstacleAction
{
    
    public override void UseObstacle(){
        Debug.Log("WALL");
    }
}
