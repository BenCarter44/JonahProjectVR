using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour
{
    public void StartSceneChanger()
    {
        GetComponent<FadeInSS>().EndFadeToScene0();
      //  SceneManager.LoadScene("Scene0");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
