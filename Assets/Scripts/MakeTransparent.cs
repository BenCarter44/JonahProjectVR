using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeTransparent : MonoBehaviour
{
    public GameObject currentGameObject;
    public Slider transparencySlider;
    void Start()
    {
        currentGameObject = gameObject;
        // capture changes in sliders and change transparency
        transparencySlider.onValueChanged.AddListener(delegate { ChangeMaterial(currentGameObject.GetComponent<Renderer>().material, 1); });
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMaterial(currentGameObject.GetComponent<Renderer>().material, 1f-transparencySlider.value);
    }

    void ChangeMaterial(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
