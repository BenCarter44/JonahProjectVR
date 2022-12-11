using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public GameObject theBlackScreen;
    private Color startColor;
    private Color stopColor;
    public float fadeDir;
    public float waitDelay;
    private float startTimer;
    private bool isFading;
    private bool isFading2;
    private bool startAdjust;
    // Start is called before the first frame update
    void Start()
    {
        startColor = new Color(0f, 0f, 0f, 0f);  // transparent screen
        stopColor = new Color(0f, 0f, 0f, 1f);   // black screen
        startTimer = Time.time;
        isFading = true;
        Image img = theBlackScreen.GetComponent<Image>();  // get the panel 
        img.color = stopColor;
        startAdjust = false;
        isFading2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startAdjust)
        {
            startAdjust = true;
            startTimer = Time.time;
        }
        if (isFading)
        {
            if (Time.time > (startTimer + fadeDir))   // if initial fade-in, if fade is done, stop the fader
            {
                Image img = theBlackScreen.GetComponent<Image>();
                img.color = startColor;
                isFading = false;
                Invoke("switchFade", waitDelay);
            }
            else // if on initial fade-in, do the fade.
            {
                Image img = theBlackScreen.GetComponent<Image>();
                Color c = Color.Lerp(stopColor, startColor, (Time.time - startTimer) / fadeDir);
                img.color = c;
            }
        }
        if (isFading2) // the second fade animation.
        {
            if (Time.time > (startTimer + fadeDir))
            {
                Image img = theBlackScreen.GetComponent<Image>();
                img.color = stopColor;
                isFading2 = false;
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
    void switchFade()
    {
        isFading2 = true;
        startAdjust = true;
        startTimer = Time.time;
    }
    void ToNextScene()
    {
        SceneManager.LoadScene("Scene2");
        
    }
}
