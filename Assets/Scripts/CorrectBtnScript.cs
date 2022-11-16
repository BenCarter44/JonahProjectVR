using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectBtnScript : MonoBehaviour
{
    private GameObject npc;
    private GameObject c;
    private GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        // finds game objects
        npc = GameObject.Find("NPC");
        c = GameObject.Find("Canvas");
        self = GameObject.Find("CorrectBtnManager");

        // restores active values
        npc.SetActive(false);
        c.SetActive(false);
        self.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when active is changed to false
    void OnDisable()
    {
        // loads classroom exam scene
        SceneManager.LoadScene("");
    }
}
