using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionScript : MonoBehaviour
{

    public GameObject uselessCanvas;
    private int uselessCount;

    // Start is called before the first frame update
    void Start()
    {
        uselessCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressUselessBtn()
    {
        uselessCount++;
        if( uselessCount >= 10)
        {
            uselessCanvas.SetActive(false);
        }
    }
}
