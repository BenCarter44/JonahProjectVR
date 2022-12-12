using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DistractionScript : MonoBehaviour
{

    public GameObject uselessBtn;
    public TMP_Text uselessText;
    private int uselessCount;

    // Start is called before the first frame update
    void Start()
    {
        uselessCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressUselessBtn()
    {
        uselessCount++;
        if(uselessCount == 100)
        {
            uselessText.text = "LOL";
            uselessBtn.SetActive(false);
        }
    }
}
