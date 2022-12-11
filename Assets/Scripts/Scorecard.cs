using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorecard : MonoBehaviour
{
    public int entrapmentReq;
    private int currentEntrapment;
    public GameObject goalScript;
    // Start is called before the first frame update
    void Start()
    {
        currentEntrapment = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEntrapment >= entrapmentReq)
        {
            // trapped!
            goalScript.GetComponent<GoalScript>().EndGame();
        }
    //    Debug.Log(currentEntrapment);
    }
    public void NewCarEnter()
    {
        currentEntrapment++;
    }
    public void NewCarExit()
    {
        currentEntrapment--;
    }
   
}
