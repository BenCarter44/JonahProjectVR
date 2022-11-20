using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class RobotAdder : MonoBehaviour
{

    public GameObject jeepReplica;
    public int maxJeeps;
    public float timeSep;
    private float timeLog;
    private List<Vector3> theSpawnPoints;
    private Stack<GameObject> createdCars;
    private int createdJeeps = 0;
    public GameObject goalMan;
    private bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        theSpawnPoints = new List<Vector3>();
        createdCars = new Stack<GameObject>();
        theSpawnPoints.Add(new Vector3(41.12579f, 1.05f, -25.56898f));
        theSpawnPoints.Add(new Vector3(121.6f, 1.05f, 87.4f));
        theSpawnPoints.Add(new Vector3(138.5f, 1.05f, -79.6f));
        theSpawnPoints.Add(new Vector3(-7.8f, 1.05f, -71.9f));
        theSpawnPoints.Add(new Vector3(-115.3f, 1.05f, 83.7f));
        jeepReplica.SetActive(false); // disable it.
        timeLog = timeSep - 5.0f; // start with 5sec delay
        goalMan.GetComponent<GoalScript>().Invoke("StartClock", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeLog = timeLog + Time.deltaTime;
        if(timeLog >= timeSep && createdJeeps < maxJeeps)
        {
            timeLog = 0;
            if (!stopped)
            {
                createJeep();
            }
        }
    }
    void createJeep()
    {
        Random rd = new System.Random();
        GameObject newJeep = GameObject.Instantiate(jeepReplica);
        newJeep.transform.position = theSpawnPoints[rd.Next(theSpawnPoints.Count)];
        newJeep.GetComponent<RobotCars>().me = newJeep;
        newJeep.GetComponent<RobotCars>().stoppingDistance = 8;
        newJeep.SetActive(true);
        createdJeeps += 1;
        createdCars.Push(newJeep);
        
    }
    public void StopCars()
    {
        stopped = true;
        foreach (GameObject i in createdCars)
        {
            i.GetComponent<RobotCars>().Invoke("StopCars", 0.01f); // stop immediately!
        }
    }
}
