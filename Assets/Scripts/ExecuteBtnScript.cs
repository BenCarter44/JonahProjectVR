using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteBtnScript : MonoBehaviour
{
    public Button btn;
    public Text report;
    public Text timeLapsed;
    public Text vText;
    public Text aText;
    public Text dText;
    public Slider mySlider;
    public GameObject theBall;

    private System.Collections.Generic.List<float> timers;
    private System.Collections.Generic.List<float> positions;
    private System.Collections.Generic.List<float> velocities;

    private float oldPosition;
    private float oldVelocity;
    private float oldTime;
    private float startTime;
    private float startPosition;

    private int fCounter = 0;
    private int fWait;

    void Start()
    {
        
      //  theBall = GameObject.Find("Falling Ball");
        btn.onClick.AddListener(TaskOnClick);
        report.text = "X = ...";
        timeLapsed.text = "t = ...";

        oldTime = Time.time;
        oldPosition = theBall.GetComponent<Transform>().position.x;
        oldVelocity = 0f;
        startPosition = oldPosition;
        startTime = Time.time;
        fWait = 20;
    }

    private void Update()
    {
        /* This captures all clicks...
        if (Input.GetMouseButtonDown(0))
        {
            timers.Add(lastClickTime > 0 ? Time.time - lastClickTime : Time.time);
            positions.Add(theBall.GetComponent<Transform>().position.x);
        }
        */
        int q = (int)mySlider.value;

        if(fCounter % q == 0)
        {
            TaskOnClick();
        }
        fCounter += 1;
        if(fCounter > int.MaxValue - 20)
        {
            fCounter = 0;
        }

    }

    void TaskOnClick()
    {
       // Debug.Log("CLICKED BUTTON");
        report.text = "X = " + theBall.GetComponent<Transform>().position.x.ToString();
        timeLapsed.text = "t = " + TimeLapsed();
      //  Debug.Log("Time lapsed: " + TimeLapsed());


        float d = HorizontalDisplacement();
        float v = Velocity();
        float a = Acceleration();

        dText.text = "d = " + d;
        vText.text = "v = " + v;
        aText.text = "a = " + a;

        oldPosition = d;
        oldVelocity = v;
    }
    private float HorizontalDisplacement()
    {
        return theBall.GetComponent<Transform>().position.x - startPosition;
    }

    private float TimeLapsed()
    {
        return Time.time - startTime;
    }

    private float Velocity()
    {
        float posREL = HorizontalDisplacement();
        float timeREL = TimeLapsed();

        float vg = (posREL - oldPosition) / (timeREL - oldTime);

        

        // X = X0 + V0*t + (a*t^2)/2
        // Since you recorded X and t, you can calculate a
        // Get X0 from the positions list
        // V0 = 0

        // Acceleration at time t:
        // a = 2*(X - X0 - V0*t)/(t^2)

        return vg;
    }

    private float Acceleration()
    {
        float velc = Velocity();
        float timeREL = TimeLapsed();

        float vg = (velc - oldVelocity) / (timeREL - oldTime);
        return vg;
    }
    public void changeFWait(float val)
    {
        fWait = (int)val;
    }
}
