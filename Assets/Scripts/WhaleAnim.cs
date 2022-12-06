using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhaleAnim : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 0.1f;

    Image img;

    // The target (cylinder) position.
    public Transform target;

    int b = 0;

    private bool isActive = false;

    public GameObject theBlackScreen;
    private float startTimer;
    public float fadeDir;
    private Color startColor;
    private Color stopColor;
    private bool startFade;

    // void Awake()
    // {
    //     img =  panel.GetComponent<Image>();
    //     // Position the cube at the origin.
    //     // transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    // // Create and position the cylinder. Reduce the size.
    //     var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    //     cylinder.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);

    //     // Grab cylinder values and place on the target.
    //     target = cylinder.transform;
    //     target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);

    //     // // Position the camera.
    //     // Camera.main.transform.position = new Vector3(0.85f, 1.0f, -3.0f);
    //     // Camera.main.transform.localEulerAngles = new Vector3(15.0f, -20.0f, -0.5f);

    //     // // Create and position the floor.
    //     // GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
    //     // floor.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
    // }

     void Start()
    {
        startColor = new Color(0f, 0f, 0f, 0f);
        stopColor = new Color(0f, 0f, 0f, 1f);
        startFade = false;
        isActive = false;
        startTimer = Time.time;
        Image img = theBlackScreen.GetComponent<Image>();
        img.color = startColor;
    }

    Vector3 translation = new Vector3(0,10,0);

    void Update()
    {
    //    Debug.Log("PIZZ");
    //    Debug.Log(isActive);
        if(isActive)
        {
            // Move our position a step closer to the target.
            
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position+translation, step);
        //    Debug.Log(transform.position);
            
            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                target.position *= -1.0f;
                b=b+1;
                img.color = new Color(0,0,0,100);
            }

        }
        if (startFade)
        {
            if(startTimer + fadeDir > Time.time)
            {
                Image img = theBlackScreen.GetComponent<Image>();
                Color c = Color.Lerp(startColor, stopColor, (Time.time - startTimer)  / fadeDir);
                img.color = c;
                if(img.color.a >= 0.9)
                {
                    SceneManager.LoadScene("Scene2");
                }
            }
        }
    }

    public void activate()
    {
        Debug.Log("whale activated");
        isActive = true;
        Invoke("activate2",0.02f);
         Debug.Log("UPD");
        Debug.Log(isActive);
        Invoke("startFadeAnim", 5.0f);
    }

    private void startFadeAnim()
    {
        startFade = true;
        startTimer=Time.time;
    }
    private void activate2()
    {
        isActive = true;
        Invoke("activate3",0.04f);
    }
    private void activate3()
    {
        isActive = true;
    }
}
