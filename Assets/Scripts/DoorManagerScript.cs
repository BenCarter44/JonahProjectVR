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
        float distB = Vector3.Distance(rotationB, check);
        float distC = Vector3.Distance(rotationC, check);
        float distD = Vector3.Distance(rotationD, check2);

        //Debug.Log("distB = " + distB);
        //Debug.Log("distC = " + distC);
        //Debug.Log("distD = " + distD);

        if (distB <= 1 && distC <= 1 && distD <= 1)
        {
            npc.SetActive(true);
        }
    }
}
