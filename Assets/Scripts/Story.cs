using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class Story : MonoBehaviour
{

    public Canvas canvas;
    public DialogueService ds;
    public TextMeshProUGUI dialogueTextBox;
    public TextMeshProUGUI actionTextBox;
    private Dialogue currentTalk;

    public TextAsset SpeechLines;

    public GameObject cutscene;
   // public GameObject me;
    private VRCustomInputManager vr;
    private bool isActive = true;
    private bool hitName;
    private List<List<string>> speechAll;
    private bool isTalking;
    private bool aaronGo = false;
    private bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueTextBox.text = "";
        actionTextBox.text = "";
    //    var content = SpeechLines.text;
     //   Debug.Log("Item");
    //    Debug.Log(content.Split("\n"));
    //    var AllWords = content.Split("\n");
     //   List<string> speechList = new List<string>(AllWords);
        
        refreshText();
     

     //   Invoke("testForce", 5f);
    //    cutscene.GetComponent<StartRain>().startRain();
       aaronGo = false;
        vr = new VRCustomInputManager();
        if (vr == null)
        {
            Debug.Log("No VR Headset!");
        }

    //     cutscene.GetComponent<StartRain>().startRain();
    }
    void testForce()
    {
        isActive = false;
        cutscene.GetComponent<Overboard>().switchCam();
    }
    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(transform.position);   
        if (isActive)
        {
            Vector3 pos = transform.position;
            if(pos.y < 3.5f)
            {
                Debug.Log("FALL ALERT!!!!");
                pos.y = 5f;
                transform.position = pos;
            }
            if(vr != null && vr.buttonY && !vr.isError && ready)
            {
                Debug.Log("A: " + hitName);
                
                Debug.Log("B: " + hitName);
                if(!isTalking)
                {
                    Debug.Log("C: " + hitName);
                    isTalking = true;
                    Invoke("nextText",0.1f);
                    
                }
                
                
                /*
                if(ds.isTalking == true)
                {
                    if (currentTalk.getIsFinished() == true)
                    {
                        dialogueTextBox.text = "";
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
                    dialogueTextBox.text = currentTalk.talk();  
                }
                else
                {
                    Debug.Log("HITNAME '" + hitName + "'");
                    currentTalk = ds.GetDialogue(hitName);
                    ds.isTalking = true;
                    dialogueTextBox.text = currentTalk.talk();
                }
                */
            } 
        }
        else
        {
            isTalking = false;
            dialogueTextBox.text = "";
        }
    
    }
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.transform.name);
        
        if(col.transform.name == "Aaron" || col.transform.name == "Bach")
        {
            
            hitName = col.transform.name != "Aaron";
            
            if(col.transform.name == "Aaron")
            {
                ready = true;
            }
            else if(aaronGo)
            {
                ready = true;
            }
            Debug.Log("Aaron Enter!");
            if(ready)
            {
                GetComponent<AudioSource>().Play();
                actionTextBox.text = "Press Y to Talk";
            }
        }
    }  
    public void OnTriggerExit(Collider col)
    {
     //   GetComponent<AudioSource>().Play();
        Debug.Log(col.transform.name);
        
        if(col.transform.name == "Aaron" || col.transform.name == "Bach")
        {
            refreshText();
            isTalking = false;
            ready = false;
            hitName = col.transform.name != "Aaron";
            
            Debug.Log("Aaron Exit!");
            if(isActive)
            {
                actionTextBox.text = " ";
            }
        }
    } 
    public void nextText()
    {
        if(!isActive)
        {
             isTalking = false;
        }
        else
        {
            if(isTalking)
            {
                actionTextBox.text = " ";
                dialogueTextBox.text = "";
                int apple = 0;
                if(hitName)
                {
                    apple = 1;
                }
                Debug.Log("D: " + apple);
                List<string> items = speechAll[apple];
                if(items.Count != 0)
                {
                    dialogueTextBox.text = items[0];
                    Invoke("nextText",5f);
                    items.RemoveAt(0);
                }
                else
                {
                    if (!hitName)
                    {
                        isTalking = false;
                        aaronGo = true;
                        cutscene.GetComponent<StartRain>().startRain();
                    }
                    else if (hitName)
                    {
                        isActive = false;
                        cutscene.GetComponent<Overboard>().switchCam();
                    }
                }

            }
            else
            {
                dialogueTextBox.text = "";
            }
        }
    }
    public void refreshText()
    {
        var content = SpeechLines.text;
        var AllWords = content.Split("\n");
        List<string> speechList = new List<string>(AllWords);
        speechAll = new List<List<string>>();
    //    ds = new DialogueService();

        string myName = "";
        for(int i = 0; i <= speechList.Count-1; i++)
        {
            
            if (speechList[i].Contains("[actor]"))
            {
                List<string> mySpeech = new List<string>();
                Debug.Log("NEW CURRENT TALK");
              //  Debug.Log(speechList[i+1]);
         //       currentTalk = new Dialogue(speechList[i+1]);
                myName = speechList[i+1]; 
                i=i+2;

                while(!speechList[i].Contains("[end]"))
                {
                    Debug.Log(speechList[i]);
                    mySpeech.Add(speechList[i]);      
     //               currentTalk.AddSpeech(speechList[i]);
                    i++;
                }
                
           //     Debug.Log("KEY: " + myName);
                
                speechAll.Add(mySpeech);
      //          ds.LoadDialogue(currentTalk);
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
        Debug.Log("Piizzzza " + id);
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