using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenBoundsCounter : MonoBehaviour
{
    private int atomsBound;
    void Start()
    {
        atomsBound = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "oxygen" && atomsBound < 1)
        {
            atomsBound += 1;
            Debug.Log("hydrogen searching for bind");
        }
        else
        {
            Debug.Log("hydrogen already bound");
        }
    }
}