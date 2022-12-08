using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Background : MonoBehaviour
{

    //using UnityEngine.SceneManagement;
    public GameObject backgroundPanel;
    
    public void hide()
    {   
        backgroundPanel.SetActive(false);
    }
    
    public void show()
    {   
        backgroundPanel.SetActive(true);
    }

    void Start()
    {
        backgroundPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}