using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameObject go;
    private List<UnityEngine.XR.InputDevice> right = new List<UnityEngine.XR.InputDevice>();
    private bool triggerValue;
    private bool openFlag;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("01_low");
        openFlag = false;
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, right);
    }

    // Update is called once per frame
    void Update()
    {
        if (right[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            ChangeRotation();
        }
    }

    void ChangeRotation()
    {
        if (!openFlag)
        {
            go.transform.Rotate(0, -90, 0);
        }
        else
        {
            go.transform.Rotate(0, 0, 0);
        }
    }
}
