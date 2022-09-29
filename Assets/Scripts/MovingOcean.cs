using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOcean : MonoBehaviour
{
    int tideHeight=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float tick = 0;
    // Update is called once per frame
    void Update()
    {
        tick = tick + 0.05f;
        transform.position =  new Vector3(0,Mathf.Sin(tick)/10,0);
        if (tick==100)
        {
            tick = 0;
        }
    }
}
