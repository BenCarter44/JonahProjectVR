// Guide: Just insert this into any cube object named 'DiscoCube'

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    private GameObject obj1;

    // Start is called before the first frame update
    void Start()
    {
        print("d");
        obj1 = GameObject.Find("DiscoCube");
        // Material object1Material = obj1.GetComponent<Renderer>().material;
        // Color initObjectColor = new Color(object1Material.color.r, object1Material.color.g, object1Material.color.b, 0);
        // object1Material.SetColor("_Color", initObjectColor);
        StartCoroutine(ChangeSizeOverTime(3));
    }

    IEnumerator ChangeSizeOverTime(float time)
    {
        
        
        print("a");
        // changes color of an objects over time, by manipulating alpha

        // Color oldColor1 = obj1.GetComponent<Renderer>().material.color;
        // Color newSize1 = new 

        float currentTime = 0.0f;
        Vector3 lerpedSize =  new Vector3(Random.Range(1,10),Random.Range(1,10),Random.Range(1,10));

        // Color oldColor1 = obj1.GetComponent<Renderer>().material.color;
        // Color newColor1 = new Color(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255), 0);

        // Color lerpedColor1;

        do
        {
            transform.localScale = Vector3.Lerp(transform.localScale, lerpedSize, currentTime / time);

            // lerpedColor1 = Color.Lerp(oldColor1, newColor1, currentTime / time);
            // obj1.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor1);
            // // lerpedSize = Color.Lerp(oldColor1, newColor1, currentTime / time);
            // obj1.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor1);

            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        StartCoroutine(ChangeSizeOverTime(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
