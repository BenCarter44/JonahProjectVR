using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour
{
    private GameObject npc;

    private Vector3 rotationB;
    private Vector3 rotationC;
    private Vector3 rotationD;
    private Vector3 check;
    private Vector3 check2;



    // Start is called before the first frame update
    void Start()
    {
        GameObject doorB = GameObject.FindWithTag("doorB");
        GameObject doorC = GameObject.FindWithTag("doorC");
        GameObject doorD = GameObject.FindWithTag("doorD");

        npc = GameObject.Find("NPC");

        rotationB = doorB.transform.GetChild(0).eulerAngles;
        rotationC = doorC.transform.GetChild(0).eulerAngles;
        rotationD = doorD.transform.GetChild(0).eulerAngles;
        check = new Vector3(-90, -90, 0);
        check2 = new Vector3(-90, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (rotationB == check && rotationC == check && rotationD == check2)
        {
            npc.SetActive(true);
        }
    }
}
