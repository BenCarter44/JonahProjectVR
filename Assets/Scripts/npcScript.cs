using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class npcScript : MonoBehaviour
{
    private GameObject npc;
    private GameObject c;

    private List<UnityEngine.XR.InputDevice> right = new List<UnityEngine.XR.InputDevice>();
    private bool triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        npc = GameObject.Find("NPC");
        c = GameObject.Find("Canvas");

        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, right);
    }

    // Update is called once per frame
    void Update()
    {
        if (right[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            c.SetActive(true);
        }
    }
}
