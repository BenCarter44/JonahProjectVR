using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour
{
    public GameObject npc;

    private Vector3 rotationB;
    private Vector3 rotationC;
    private Vector3 rotationD;
    private Vector3 check;
    private Vector3 check2;

    private int openCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject doorB = GameObject.FindWithTag("doorB");
        GameObject doorC = GameObject.FindWithTag("doorC");
        GameObject doorD = GameObject.FindWithTag("doorD");

        rotationB = doorB.transform.GetChild(0).eulerAngles;
        rotationC = doorC.transform.GetChild(0).eulerAngles;
        rotationD = doorD.transform.GetChild(0).eulerAngles;
        check = new Vector3(-90, -90, 0);
        check2 = new Vector3(-90, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        // not sure why but first part of condition does not work
        if ((rotationB == check) & (rotationC == check) & (rotationD == check2) | (openCount == 3))
        {
            npc.SetActive(true);
        }
    }

    public void openDoorB()
    {
        GetComponent<AudioSource>().Play();

        Vector3 openRotate = new Vector3(-90, -90, 0);

        GameObject door = GameObject.FindWithTag("doorB");
        door.transform.GetChild(0).eulerAngles = openRotate;
        openCount++;
    }

    public void openDoorC()
    {
        GetComponent<AudioSource>().Play();

        Vector3 openRotate = new Vector3(-90, -90, 0);

        GameObject door = GameObject.FindWithTag("doorC");
        door.transform.GetChild(0).eulerAngles = openRotate;
        openCount++;
    }

    public void openDoorD()
    {
        GetComponent<AudioSource>().Play();

        Vector3 openRotate = new Vector3(-90, 0, 0);

        GameObject door = GameObject.FindWithTag("doorD");
        door.transform.GetChild(0).eulerAngles = openRotate;
        openCount++;
    }
}
