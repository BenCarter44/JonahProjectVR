using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public GameObject RobotCarsMan;
    public GameObject theBlackScreen;
    private float startTimer;
    public float fadeDir;
    private Color startColor;
    private Color stopColor;
    private bool startFade;
    // Start is called before the first frame update
    void Start()
    {
        startColor = new Color(0f, 0f, 0f, 0f);
        stopColor = new Color(0f, 0f, 0f, 1f);
        startFade = true;
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer + fadeDir > Time.time)
        {
            Image img = theBlackScreen.GetComponent<Image>();
            Color c = Color.Lerp(startColor, stopColor, (Time.time - startTimer)  / fadeDir);
            img.color = c;
        }
        
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
