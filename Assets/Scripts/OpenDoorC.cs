using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorC : MonoBehaviour
{
    private GameObject parentDoor;
    private GameObject childDoor;
    private Vector3 openRotate;

    // Start is called before the first frame update
    void Start()
    {
        parentDoor = GameObject.Find("DoorC");
        childDoor = parentDoor.transform.GetChild(0).gameObject;
        openRotate = new Vector3(-90, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnable()
    {
        childDoor.transform.eulerAngles = openRotate;
    }
}
