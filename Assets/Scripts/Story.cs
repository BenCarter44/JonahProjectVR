using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Story : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Canvas canvas;
    public DialogueService ds;
    public Text dialogueTextBox;
    public Text actionTextBox;

    private Dialogue currentTalk;

    public TextAsset SpeechLines;

    public GameObject cutscene;

    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        var content = SpeechLines.text;
        var AllWords = content.Split("\n");
        List<string> speechList = new List<string>(AllWords);

        ds = new DialogueService();

        for(int i = 0; i <= speechList.Count-1; i++)
        {
            if (speechList[i].Contains("[actor]"))
            {
                currentTalk = new Dialogue(speechList[i+1]);
                
                i=i+2;

                while(speechList[i] != "[end]")
                {
                    currentTalk.AddSpeech(speechList[i]);
                    i++;
                }
                ds.LoadDialogue(currentTalk);
            }
        }
        Invoke("testForce", 5f);
        // ds.GetDialogue("Aaron").setTask(cutscene.GetComponent<StartRain>().startRain());
    }
    void testForce()
    {
        isActive = false;
        cutscene.GetComponent<Overboard>().switchCam();
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "approachable")
                {
                    actionTextBox.GetComponent<Text>().text = "Press F to Talk";

                    if(Input.GetKeyDown("f"))
                    {
                        if(ds.isTalking == true)
                        {
                            if (currentTalk.getIsFinished() == true)
                            {
                                dialogueTextBox.GetComponent<Text>().text = "";
                                //HARD CODED - THIS CAN BE BETTER
                                if (currentTalk.getDialogueId() == "Aaron")
                                {
                                    
                                    cutscene.GetComponent<StartRain>().startRain();
                                }
                                if (currentTalk.getDialogueId() == "Bach")
                                {
                                    isActive = false;
                                    cutscene.GetComponent<Overboard>().switchCam();
                                }
                                ds.isTalking = false;
                            }
                            dialogueTextBox.GetComponent<Text>().text = currentTalk.talk();
                        }
                        else
                        {
                            currentTalk = ds.GetDialogue(hit.collider.name);
                            ds.isTalking = true;
                            dialogueTextBox.GetComponent<Text>().text = currentTalk.talk();
                        }
                        
                        print(hit.collider.name);
                    }
                }
                else
                {
                    actionTextBox.GetComponent<Text>().text = " ";
                }
            }
    }
}

public class DialogueService
{
    private List<Dialogue> dialogues = new List<Dialogue>();
    private string currentDialogue;
    public bool isTalking = false;

    public void LoadDialogue(Dialogue d)
    {
        dialogues.Add(d);
    }
    public Dialogue GetDialogue(string id)
    {
        foreach (Dialogue d in dialogues)
        {
            if(d.getDialogueId()==id)
            {
                return d;
            }
        }
        Debug.Log("Error: No such id exists");
        return null;
    }
    public bool getIsTalking()
    {
        return isTalking;
    }
}

public class Dialogue
{
    private string dialogueid;
    private List<string> speech = new List<string>();
    private bool hasStarted = false;
    private bool isFinished = false;
    private int count = 0;
    private delegate void Action();
    private Action task;
    public Dialogue(string id)
    {
        Debug.Log(id + " has been created");
        dialogueid = id;
    }
    public void AddSpeech(string text)
    {
        speech.Add(text);
        count++;
    }
    public string talk()
    {
        if (speech.Count == 0)
        {
            isFinished = true;
            return "";
        }
        hasStarted = true;
        string s = speech[0];
        speech.RemoveAt(0);
        return s;
    }
    public string getDialogueId()
    {
        return dialogueid;
    }
    public bool getHasStarted()
    {
        return hasStarted;
    }
    public int getCount()
    {
        return count;
    }
    public bool getIsFinished()
    {
        return isFinished;
    }
    // public void setTask(delegate something())
    // {
    //     task = a;
    // }
    public void doTask()
    {
        task();
    }
}