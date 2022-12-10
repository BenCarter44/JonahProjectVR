using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // not sure why but first part of condition does not work second part is a failsafe
        if ((rotationB == check) & (rotationC == check) & (rotationD == check2) | (openCount == 3))
        {
            npc.SetActive(true);
        }
    }

    IEnumerator OpenDoorOverTime(float duration, GameObject go, Vector3 start, Vector3 end)
    {
        float time = 0.0f;
        Vector3 lerpRotate;


        do
        {
            lerpRotate = new Vector3(start.x, Mathf.Lerp(start.y, end.y, time / duration), start.z);
            go.transform.GetChild(0).eulerAngles = lerpRotate;

            time += Time.deltaTime;
            yield return null;
        } while (time <= duration);
    }

    public void openDoorB()
    {
        GetComponent<AudioSource>().Play();
        GameObject door = GameObject.FindWithTag("doorB");
        Vector3 closedRotate = door.transform.GetChild(0).eulerAngles;
        Vector3 openRotate = new Vector3(-90, -90, 0);

        StartCoroutine(OpenDoorOverTime(2f, door, closedRotate, openRotate));

        Collider c = door.GetComponent<Collider>();
        c.enabled = !c.enabled;
        openCount++;
    }

    public void openDoorC()
    {
        GetComponent<AudioSource>().Play();
        GameObject door = GameObject.FindWithTag("doorC");
        Vector3 closedRotate = door.transform.GetChild(0).eulerAngles;
        Vector3 openRotate = new Vector3(-90, -90, 0);

        StartCoroutine(OpenDoorOverTime(2f, door, closedRotate, openRotate));

        Collider c = door.GetComponent<Collider>();
        c.enabled = !c.enabled;
        openCount++;
    }

    public void openDoorD()
    {
        GetComponent<AudioSource>().Play();
        GameObject door = GameObject.FindWithTag("doorD");
        Vector3 closedRotate = door.transform.GetChild(0).eulerAngles;
        Vector3 openRotate = new Vector3(-90, 0, 0);

        StartCoroutine(OpenDoorOverTime(2f, door, closedRotate, openRotate));

        Collider c = door.GetComponent<Collider>();
        c.enabled = !c.enabled;
        openCount++;
    }
}
