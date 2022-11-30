using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongBtnScript : MonoBehaviour
{
    private GameObject npc;
    private GameObject c;
    private GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        // finds game objects
        npc = GameObject.Find("NPC");
        c = GameObject.Find("CanvasNPC");
        self = GameObject.Find("CorrectBtnManager");

        // restores active values
        npc.SetActive(false);
        c.SetActive(false);

        // loads scooter crash scene
        SceneManager.LoadScene(1);// placeholder        
        
        self.SetActive(false);

    }

    // Called when active is changed to false
    public void OnDisable()
    {
        
    }
}
