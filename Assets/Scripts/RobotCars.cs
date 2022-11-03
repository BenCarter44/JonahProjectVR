using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotCars : MonoBehaviour
{

    public GameObject theMainPlayer;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = theMainPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = theMainPlayer.transform.position; 
    }
}
