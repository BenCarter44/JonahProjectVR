using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overboard : MonoBehaviour
{
    public Camera mainCam;
    public Camera whaleCam;
    public GameObject whale;
    private Animator animator;
    

    
void Start()
{
    whaleCam.gameObject.SetActive(false);
    animator = whaleCam.GetComponent<Animator>();
}

    public void switchCam()
    {
        whaleCam.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        animator.Play("whaleCamCutscene");
        whale.GetComponent<WhaleAnim>().activate();
    }

    
}
