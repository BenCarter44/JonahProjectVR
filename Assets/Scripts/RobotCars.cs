using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 *  This program spawns Robot Cars on random locations of the map. The user tries to run away from the cars to reach the destination.
 * 
 * 
 */

public class RobotCars : MonoBehaviour
{

    public GameObject theMainPlayer;
    public GameObject scoreCard;
    private NavMeshAgent agent;
    public GameObject me;
    private bool stopCars = false;
    private bool entrapped = false;
    private bool triggerEnt = false;
    private float minDist;
  //  public static

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = theMainPlayer.transform.position;
        stopCars = true;
        minDist = 0.0f;
      //  Debug.Log(transform.position);
        agent.enabled = false;
       // Invoke("StopCars",20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(me.transform.position,theMainPlayer.transform.position) < minDist)
        {
            triggerEnt = true;
        }
        if(!stopCars && !triggerEnt)
        {
            agent.destination = theMainPlayer.transform.position;
            agent.enabled = true;
        //    Debug.Log(transform.position);
            if(entrapped)
            {
                scoreCard.GetComponent<Scorecard>().NewCarExit();
            }
            entrapped = false;
           // agent.isStopped = false;
        }
        else
        {
            if (triggerEnt)
            {
                if (!entrapped)
                {
                    scoreCard.GetComponent<Scorecard>().NewCarEnter();
                }
                entrapped = true;
            }
            //agent.isStopped = true;
            agent.enabled = false;
            
        }
       
    }
    public void StopCars()
    {
        Debug.Log("Stopped!");
        stopCars = true;
    }
    public void StartCars()
    {
        Debug.Log("Start!");
        stopCars = false;
    }
    void OnTriggerEnter(Collider col)
    {
        minDist = Vector3.Distance(me.transform.position,theMainPlayer.transform.position);

        if(col.transform.name == "XR Origin")
        {
            triggerEnt = true;
            Debug.Log("HELLOHELLO!!!!!");
        }
        else if(col.transform.tag == "bookgen")
        {

        }
    }

    void OnTriggerExit(Collider col)
    {
        minDist = 0f;
        if(col.transform.name == "XR Origin")
        {
            Invoke("waitLater",0.25f);
        }
    }
    void waitLater()
    {
        triggerEnt = false;
    }
    /*
    public void OnSelect()
    {
        agent.enabled = false;
        agent.isStopped = true;
        driver = true;
    } */
}
