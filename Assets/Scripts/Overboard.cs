using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overboard : MonoBehaviour
{
    public Camera mainCam;
    public Camera whaleCam;
    public GameObject whale;
    
void Start()
{
    whaleCam.gameObject.SetActive(false);
}

    public void switchCam()
    {
        whaleCam.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        whale.GetComponent<WhaleAnim>().activate();
    }
}
