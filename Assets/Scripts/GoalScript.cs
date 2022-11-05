using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject RobotCarsMan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
      //  Debug.Log(col);
        if(col.transform.name == "XR Origin")
        {
            Debug.Log("Win!");
            RobotCarsMan.GetComponent<RobotAdder>().Invoke("StopCars",1);
        }
    }
}
