using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overboard : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject whaleCam;
    public GameObject whale;
    private Animator animator;
    

    
void Start()
{
 //   whaleCam.SetActive(false);
    animator = whaleCam.GetComponent<Animator>();
}

    public void switchCam()
    {
        Debug.Log("SWITCH CAM!!!!!!!!!!!!!!!!!!");
      //  whaleCam.SetActive(true);
    //    mainCam.SetActive(false);
        whale.SetActive(true);
        whaleCam.GetComponent<Animator>().enabled = true;
        whale.GetComponent<WhaleAnim>().activate();
    }

    
}
