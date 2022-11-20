using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 openRotate = new Vector3(-90, -90, 0);

        GameObject door = GameObject.FindWithTag("doorC");
        door.transform.GetChild(0).eulerAngles = openRotate;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
