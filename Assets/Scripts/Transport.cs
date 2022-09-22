using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Transport : MonoBehaviour
{
    public Button initiateTransport;

    private GameObject object1;
    private GameObject object2;

    private float fullyVisible = 1;
    private float fullyTransparent = 0;

    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Stop();

        object1 = GameObject.Find("Cylinder1");
        object2 = GameObject.Find("Cylinder2");

        Material object1Material = object1.GetComponent<Renderer>().material;
        Material object2Material = object2.GetComponent<Renderer>().material;

        object2.SetActive(false);
        Color initObject2Color = new Color(object2Material.color.r, object2Material.color.g, object2Material.color.b, fullyTransparent);
        object2Material.SetColor("_Color", initObject2Color);

       initiateTransport.onClick.AddListener(TasksOnClick);
    }


    void Update()
    {
        
    }

    IEnumerator ChangeColorOverTime(float time, GameObject obj1, GameObject obj2)
    {
        // changes color of an objects over time, by manipulating alpha

        Color oldColor1 = obj1.GetComponent<Renderer>().material.color;
        Color newColor1 = new Color(oldColor1.r, oldColor1.g, oldColor1.b, fullyTransparent);

        Color oldColor2 = obj2.GetComponent<Renderer>().material.color;
        Color newColor2 = new Color(oldColor2.r, oldColor2.g, oldColor2.b, fullyVisible);

        float currentTime = 0.0f;
        Color lerpedColor1;
        Color lerpedColor2;

        do
        {
            lerpedColor1 = Color.Lerp(oldColor1, newColor1, currentTime / time);
            obj1.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor1);

            lerpedColor2 = Color.Lerp(oldColor2, newColor2, currentTime / time);
            obj2.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor2);

            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    
    void TasksOnClick()
    {
        // executed when the "Initiate Transport" button is clicked
        object2.SetActive(true);
        StartCoroutine(ChangeColorOverTime(3f, object1,object2));
        audioData.Play(0);
        
    }

    
    void ChangeMaterial(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
