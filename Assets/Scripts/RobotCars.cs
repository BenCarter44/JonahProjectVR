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
    private NavMeshAgent agent;
    public float stoppingDistance;
    public GameObject me;
    private bool stopCars = false;
  //  public static

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = theMainPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopCars && Vector3.Distance(theMainPlayer.transform.position,me.transform.position) > stoppingDistance)
        {
            agent.destination = theMainPlayer.transform.position;
            agent.enabled = true;
           // agent.isStopped = false;
        }
        else
        {
            //agent.isStopped = true;
            agent.enabled = false;
            
        }
    }
    public void StopCars()
    {
        Debug.Log("Stopped!");
        stopCars = true;
    }
    /*
    public void OnSelect()
    {
        agent.enabled = false;
        agent.isStopped = true;
        driver = true;
    } */
}
