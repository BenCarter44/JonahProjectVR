using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour
{
    private GameObject doorB;
    private GameObject doorC;
    private GameObject doorD;
    private GameObject npc;

    private Vector3 rotationB;
    private Vector3 rotationC;
    private Vector3 rotationD;
    private Vector3 check;


    // Start is called before the first frame update
    void Start()
    {
        doorB = GameObject.Find("DoorB");
        doorC = GameObject.Find("DoorC");
        doorD = GameObject.Find("DoorD");
        npc = GameObject.Find("NPC");

        rotationB = doorB.transform.GetChild(0).eulerAngles;
        rotationC = doorC.transform.GetChild(0).eulerAngles;
        rotationD = doorD.transform.GetChild(0).eulerAngles;
        check = new Vector3(-90, -90, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(rotationB == check && rotationC == check && rotationD == check)
        {
            npc.SetActive(true);
        }
    }
}
