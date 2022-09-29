using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour // make sure that the name of the class is the same as the name of the file!
{ // there is three types of C#. Standard C#, .NET C#, and Unity C#. Unity C# is standard C# with more libraries that come shipped.
    // Start is called before the first frame update

    public GameObject gameObjectToClick; // instance variable .. you can declare the objects that the instance variables are set to...
    public string sceneToGo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked"); // this is the System.println.out() 
        SceneManager.LoadScene(sceneToGo);
    }
}
