using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{

    public GameObject prefabCar;

    // Start is called before the first frame update
    void Start()
    {
        // instantiate object from prefab
        // for (int i = 0; i < 5; i++) 
        // {
        //     GameObject carClone = Instantiate(prefabCar, new Vector2(i, i), Quaternion.identity);
        //     carClone.tag = "TCar";
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
