using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 openRotate = new Vector3(-90, 0, 0);

        GameObject door = GameObject.FindWithTag("doorD");
        door.transform.GetChild(0).eulerAngles = openRotate;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
