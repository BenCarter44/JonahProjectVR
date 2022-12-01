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
    whaleCam.SetActive(false);
    animator = whaleCam.GetComponent<Animator>();
}

    public void switchCam()
    {
        whaleCam.SetActive(true);
        mainCam.SetActive(false);
        animator.Play("whaleCamCutscene");
        whale.GetComponent<WhaleAnim>().activate();
    }

    
}
