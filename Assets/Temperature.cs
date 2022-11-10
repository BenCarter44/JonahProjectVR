using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public float tp;
    public static float temperature = 16f;

    // Start is called before the first frame update
    public static float GetTemperature()
    {
        return temperature;
    }
    
    void Start()
    {
        temperature = tp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
