using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMan : MonoBehaviour
{
    public GameObject hydrogenBase;
    public GameObject oxygenBase;
    public GameObject heliumBase;

    public int numHydrogen;
    public int numOxygen;
    public int numHelium;

    private int totHy;
    private int totOxy;
    private int totHl;

    public float secHydrogen;
    public float secOxygen;
    public float secHelium;

    private float timer1;
    private float timer2;
    private float timer3;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = Time.time;
        timer2 = Time.time;
        timer3 = Time.time;
    }

    private void spawnHydrogen()
    {
        GameObject n = GameObject.Instantiate(hydrogenBase);
    //    n.transform.position = 0.0f;
    //    n.GetComponent<RobotCars>().me = n;
    //    n.GetComponent<RobotCars>().electroNeg = 1;
        n.SetActive(true);
        totHy += 1;
    }
    private void spawnHelium()
    {
        GameObject n = GameObject.Instantiate(heliumBase);
    //    n.transform.position = 0.0f;
    //    n.GetComponent<RobotCars>().me = n;
    //    n.GetComponent<RobotCars>().electroNeg = 0;
        n.SetActive(true);
        totHl += 1;
    }
    private void spawnOxygen()
    {
        GameObject n = GameObject.Instantiate(oxygenBase);
   //     n.transform.position = 0.0f;
   //     n.GetComponent<RobotCars>().me = n;
    //    n.GetComponent<RobotCars>().electroNeg = 1;
        n.SetActive(true);
        totOxy += 1;
    }


    // Update is called once per frame
    void Update()
    {
        if(totHy < numHydrogen && Time.time > timer1 + secHydrogen)
        {
            spawnHydrogen();
            timer1 = Time.time;
        }
        if (totHl < numHelium && Time.time > timer2 + secHelium)
        {
            spawnHelium();
            timer2 = Time.time;
        }
        if (totOxy < numOxygen && Time.time > timer3 + secOxygen)
        {
            spawnOxygen();
            timer3 = Time.time;
        }

    }
}
