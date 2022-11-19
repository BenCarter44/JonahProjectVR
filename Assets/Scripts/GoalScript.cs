using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject RobotCarsMan;
    public GameObject theBlackScreen;
    private TextMeshProUGUI timerCounter;
    private TextMeshProUGUI infoDialog;


    public GameObject tmCount;
    public GameObject infDiag;

    private float startTimer;
    public float fadeDir;
    private Color startColor;
    private Color stopColor;
    private bool startFade;
    private float waitTimer;
    private bool waitReset;
    public int startClockAmount;
    private bool clockStarted;
    private float clockEpicStart;
    // Start is called before the first frame update
    void Start()
    {
        clockStarted = false;

        Component[] components = tmCount.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }


        timerCounter = tmCount.GetComponent<TextMeshProUGUI>();
        infoDialog = infDiag.GetComponent<TextMeshProUGUI>();
        startColor = new Color(0f, 0f, 0f, 0f);
        stopColor = new Color(0f, 0f, 0f, 1f);
        startFade = false;
        waitReset = false;
        startTimer = Time.time;
       // timerCounter.text = "Time: " + startClockAmount;
        timerCounter.text = "GET READY!";
        infoDialog.text = "Go to the Thunderground!";
    }

    // Update is called once per frame
    void Update()
    {
        if(!startFade)
        {
            if (clockStarted)
            {
                if (Time.time - clockEpicStart > 1.0f)
                {
                    startClockAmount--;
                    timerCounter.text = "Time: " + startClockAmount;
                    clockEpicStart = Time.time;
                } 
            }
            else
            {
                // start, 5sec delay...
                timerCounter.text = "GET READY!";
            }
        }
        if (startFade)
        {
            if (!waitReset && Time.time - waitTimer > 5.0f) // 5 sec delay till the end!
            {
                startTimer = Time.time;
                waitReset = true;
            }
            else
            {
                if (Time.time > (startTimer + fadeDir))
                {
                    Image img = theBlackScreen.GetComponent<Image>();
                    img.color = stopColor;
                    Invoke("ToNextScene", 1f);
                }
                else
                {
                    Image img = theBlackScreen.GetComponent<Image>();
                    Color c = Color.Lerp(startColor, stopColor, (Time.time - startTimer) / fadeDir);
                    img.color = c;
                }
            }
            
        }
        
    }
    void OnTriggerEnter(Collider col)
    {
      //  Debug.Log(col);
        if(col.transform.name == "XR Origin")
        {
            Debug.Log("Win!");
            RobotCarsMan.GetComponent<RobotAdder>().Invoke("StopCars",1);
           
            startTimer = Time.time;
            waitTimer = Time.time;
            startFade = true;
            
        }
    }
    void StartClock()
    {
        if (!clockStarted)
        {
            clockStarted = true;
            clockEpicStart = Time.time;
            timerCounter.text = "Time: " + startClockAmount;
        }
    }
    void ToNextScene()
    {
        SceneManager.LoadScene("Scene3b");
    }
}
