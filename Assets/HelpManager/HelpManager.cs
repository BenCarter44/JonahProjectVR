using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{

    public GameObject theHelpImage;
  //  public GameObject[] allOtherCanvases;

   // public string sceneName;
    private VRCustomInputManager vr;

    private bool isHelp;
    private bool btnRelease;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PIZZA");
        Debug.Log("PIZZA");
        isHelp = false;
        btnRelease = true;
        theHelpImage.SetActive(false);
      //  Invoke("ShowHelp222", 2f);
        vr = new VRCustomInputManager();
        if (vr == null)
        {
            Debug.Log("No VR Headset!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vr.buttonX && !vr.isError);
        if (vr != null && vr.buttonX && !vr.isError)
        {
            if(!isHelp && btnRelease)
            {
                isHelp = true;
                btnRelease = false;
            }
            
            if(isHelp && btnRelease)
            {
                isHelp = false;
                btnRelease = false;
            }
        }
        else
        {
            btnRelease = true;
        }

        // checkrun
        if(isHelp)
        {
            theHelpImage.SetActive(true);
         /*   for(int x = 0; x < allOtherCanvases.Length; x++)
            {
                allOtherCanvases[x].SetActive(false);
            } */
        }
        else
        {
            theHelpImage.SetActive(false);
            /*
            for (int x = 0; x < allOtherCanvases.Length; x++)
            {
                allOtherCanvases[x].SetActive(true);
            }
            */
        }
    

    }
    public bool IsCurrentlyHelp()
    {
        return isHelp;
    }
    public void ShowHelp222()
    {
        Debug.Log("HEREERERE");
        isHelp = true;
    }
}
