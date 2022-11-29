using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class RobotAdder : MonoBehaviour
{

    private int[] bookExclude = { 6, 7, 11, 12, 13, 17, 18, 19, 23, 24, 25, 28, 36, 37 }; // valid is 1 - 67
    private List<int> bookNum;
    public int maxJeeps;
    public float timeSep;
    private float timeLog;
   // public GameObject jeepReplica;
    private List<Vector3> theSpawnPoints;
    private Stack<GameObject> createdCars;
    private int createdJeeps = 0;
    public GameObject goalMan;
    private bool stopped = false;
    private int createCounter;
    private SortedSet<int> bookSet;
    public GameObject mainPlayer;


    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        theSpawnPoints = new List<Vector3>();
        createdCars = new Stack<GameObject>();


        for (int x = 0; x < spawnPoints.Length; x++)
        {
            Vector3 i = spawnPoints[x].transform.position;
            i.y = 3f;
            theSpawnPoints.Add(i);
            spawnPoints[x].SetActive(false);
        }

       // jeepReplica.SetActive(false); // disable it.
        timeLog = -500000;

        bookNum = new List<int>();
        bookSet = new SortedSet<int>();

        Random rd = new System.Random();
        for (int x = 1; x < 68; x++)
        {
            if(binarySearch(bookExclude,bookExclude.Length,x) != -1)
            {
                bookSet.Add(x);
                bookNum.Add(x);
            }
        }
        
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
        int gameObjNumber = bookNum[createCounter];

        
        //GameObject newJeep = GameObject.Instantiate(jeepReplica);
        string fixedCount = "" + (gameObjNumber);
        if (gameObjNumber < 10)
        {
            fixedCount = "0" + (gameObjNumber);
        }

        Debug.Log("QA_Books/Models/Book_" + fixedCount);
        GameObject newJeep = (GameObject)Instantiate(Resources.Load("QA_Books/Models/Book_" + fixedCount));
        createCounter++;
        if(createCounter >= bookNum.Count)
        {
            createCounter = 0;
        }

        newJeep.AddComponent<RobotCars>();
        newJeep.AddComponent<BoxCollider>();
        newJeep.AddComponent<Rigidbody>();


        newJeep.SetActive(false);


        newJeep.transform.position = theSpawnPoints[rd.Next(theSpawnPoints.Count)];
        newJeep.transform.localScale = new Vector3(10f, 10f, 10f);
        Debug.Log(newJeep.transform.position);

        newJeep.GetComponent<Rigidbody>().mass = 1000;

        newJeep.GetComponent<RobotCars>().me = newJeep;
        newJeep.GetComponent<RobotCars>().theMainPlayer = mainPlayer;
        newJeep.GetComponent<RobotCars>().stoppingDistance = 8;

        newJeep.AddComponent<UnityEngine.AI.NavMeshAgent>();
        newJeep.GetComponent<UnityEngine.AI.NavMeshAgent>().baseOffset = 0f;
        newJeep.GetComponent<UnityEngine.AI.NavMeshAgent>().height = .25f;
        newJeep.GetComponent<UnityEngine.AI.NavMeshAgent>().height = .1f;

        newJeep.SetActive(true);
        newJeep.GetComponent<RobotCars>().Invoke("StartCars", 0.01f);
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
    public void ready()
    {
        timeLog = timeSep - 4.98f; // start with 5sec delay
        goalMan.GetComponent<GoalScript>().Invoke("StartClock", 5.0f);
       // timeSep - 5.0f; // start with 5sec delay
    }
    public static int binarySearch(int[] myList, int len, int lookFor)
    {
        // 1,2,5,8,15,17,20
        int targetStart = 0;
        int targetEnd = len;
        while (targetStart < targetEnd - 1) // while the target minilist is longer than 1
        {
            // cout << targetStart << " " << targetEnd << '\n';
            if (myList[(targetStart + targetEnd) / 2] > lookFor)
            {
                targetEnd = (targetStart + targetEnd) / 2;
            }
            else if (myList[(targetStart + targetEnd) / 2] < lookFor)
            {
                targetStart = (targetStart + targetEnd) / 2;
            }
            else
            {
                return (targetStart + targetEnd) / 2;
            }
        }
        if (targetStart == targetEnd && lookFor == myList[targetStart])
        {
            return targetStart;
        }
        return -1;



    }
}
