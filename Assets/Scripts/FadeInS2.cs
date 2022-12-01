using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeInS2 : MonoBehaviour
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
    private bool sceneSel;
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
        sceneSel = false;
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
               // Invoke("switchFade", waitDelay);
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
    public void EndFadeToScene3()
    {
        sceneSel = false;
        isFading2 = true;
        startAdjust = true;
        startTimer = Time.time;
    }
    public void EndFadeToScene4()
    {
        sceneSel = true;
        isFading2 = true;
        startAdjust = true;
        startTimer = Time.time;
    }
    void ToNextScene()
    {
        if (sceneSel)
        {
            SceneManager.LoadScene("Scene4");
        }
        else
        {
            SceneManager.LoadScene("Scene3");
        }
    }
}
