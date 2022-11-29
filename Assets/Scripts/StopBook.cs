using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBook : MonoBehaviour
{
    public GameObject me;
    public float floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(me.transform.position.y < floor)
        {
            Destroy(me);
        }
    }
}
