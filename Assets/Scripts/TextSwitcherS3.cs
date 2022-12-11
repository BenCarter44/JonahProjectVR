using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSwitcherS3 : MonoBehaviour
{
    public TextMeshProUGUI missionBoard;
    public TextMeshProUGUI missionBoardSub;
    public TextMeshProUGUI timerBoard;
    public TextMeshProUGUI mainIntroText;
    public TextMeshProUGUI mainIntroTextSub;
    // Start is called before the first frame update
    void Start()
    {
        missionBoard.text = "Meet your friends at the Thunderground!";
        missionBoardSub.text = "Watch out for your homework!";
        timerBoard.text = "GET READY!";
        mainIntroText.text = "Your friends are at the Thunderground!";
        mainIntroTextSub.text = "You have 1 minute to meet them";

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void timeUpText()
    {
        missionBoard.text = "";
        missionBoardSub.text = "";
        timerBoard.text = "TIME: 0";
        mainIntroText.text = "Your friends couldn't wait for you any longer so they left you";
        mainIntroTextSub.text = "";

    }
    public void trappedText()
    {
        missionBoard.text = "";
        missionBoardSub.text = "";
        timerBoard.text = "";
        mainIntroText.text = "Your homework caught up to you!";
        mainIntroTextSub.text = "Couldn't run away from your work this time!";
    }
    public void plain()
    {
         missionBoard.text = "Meet your friends at the Thunderground!";
        missionBoardSub.text = "Watch out for your homework!";
       
        mainIntroText.text = "";
        mainIntroTextSub.text = "";

    }
}
