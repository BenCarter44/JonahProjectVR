using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(MazeConstructor))]

public class GameController2 : MonoBehaviour
{
    //1
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject localMover;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text scoreLabel;

    private MazeConstructor generator;
    public GameObject gameController;

    //2
    private DateTime startTime;
    private int timeLimit;
    private int reduceLimitBy;

    private int score;
    private bool goalReached;
  

    //3
    void Start()
    {
        generator = gameController.GetComponent<MazeConstructor>(); // get it off of the same object that this file is attached to.
      //  generator.generateMaze(13, 15);
        StartNewGame();
    }

    //4
    private void StartNewGame()
    {
        timeLimit = 120;
        reduceLimitBy = 5;
        startTime = DateTime.Now;

        score = 0;
        scoreLabel.text = score.ToString();

        StartNewMaze();
    }

    //5
    private void StartNewMaze()
    {
       // generator.Awake();
        generator.GenerateMaze(25, 25);
        generator.DisplayMaze();
        Debug.Log("===");
        Debug.Log(generator.startRow);
        Debug.Log(generator.startCol);
        Debug.Log("---");
        generator.PlaceGoalTrigger(OnGoalTrigger);
        generator.PlaceStartTrigger(OnStartTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;
        player.transform.position = new Vector3(x, y, z);
        Debug.Log(x);
        Debug.Log(z);
        goalReached = false;
      //  localMover.enabled = true;
        generator.DisplayCrumbs();
        if(generator.isImpossible)
        {
            Debug.Log("Impossible!!");
           // localMover.GetComonent<LocomotiveMotion>.enabled = false;

            Invoke("StartNewMaze", 4);
            return;
        }
        // restart timer
        timeLimit -= reduceLimitBy;
        startTime = DateTime.Now;

      

    }

    //6
    void Update()
    {
   /*     if (!localMover.enabled)
        {
            return;
        }
     */   

        int timeUsed = (int)(DateTime.Now - startTime).TotalSeconds;
        int timeLeft = timeLimit - timeUsed;

        if (timeLeft > 0)
        {
            timeLabel.text = timeLeft.ToString();
        }
        else
        {
            timeLabel.text = "TIME UP";
        //    localMover.enabled = false;

            Invoke("StartNewGame", 4);
        }
    }

    //7
    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("Goal!");
        goalReached = true;

        score += 1;
        scoreLabel.text = score.ToString();

        Destroy(trigger);
    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
        if (goalReached)
        {
            Debug.Log("Finish!");
//            localMover.enabled = false;

            Invoke("StartNewMaze", 4);
        }
    }
}