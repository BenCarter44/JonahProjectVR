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
	float angle = 0;
    // Update is called once per frame
    void Update()
    {
        tick++;
		if (tick % 10 == 0){angle=angle+0.01f;};
        transform.position =  new Vector3(0,0,0);
        transform.localEulerAngles = new Vector3(Mathf.Sin(angle),0,0);
    }
}
