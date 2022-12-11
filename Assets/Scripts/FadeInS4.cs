using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeInS4 : MonoBehaviour
{
    public GameObject theBlackScreen;
    public GameObject theFinalie;
    private Color startColor;
    private Color stopColor;
    public float fadeDir;
   // public float waitDelay;
    private float startTimer;
    private bool isFading;
    private bool isFading2;
    private bool startAdjust;
    public GameObject soundPlayer;
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
        theFinalie.SetActive(true);
        Invoke("playSound", 2f);
    }
    void playSound()
    {
        soundPlayer.SetActive(true);
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
                theFinalie.SetActive(true);
              //  Invoke("switchFade", waitDelay);
            }
            else // if on initial fade-in, do the fade.
            {
                Image img = theBlackScreen.GetComponent<Image>();
                Color c = Color.Lerp(stopColor, startColor, (Time.time - startTimer) / fadeDir);
                img.color = c;
            }
        }
        
    }
    public void SceneReturn()
    {
        SceneManager.LoadScene("SplashScreenStart 1");
    }
}
