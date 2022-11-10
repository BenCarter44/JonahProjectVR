using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grow : MonoBehaviour
{
    public Button runSimulationBtn;
    public Text growthInfo, setGoal, treeGrowthInfo, treeWaterGoal;

    public Slider pillarGrowthSlider;
    public Slider goalSetterSlider;

    public Slider treeGrowthSlider;
    public Slider treeWaterGoalSlider;

    private GameObject pillar;
    private GameObject tree;

    private Vector3 originalScale, originalPosition;
    private Vector3 originalTreeScale, originalTreePosition;

    public ParticleSystem rain;
    public GameObject cloud;
    void Start()
    {
        pillar = GameObject.Find("Pillar");
        tree = GameObject.Find("Fir_Tree");

        setGoal.text = "Growth Goal: ";

        originalPosition = pillar.transform.position;
        originalScale = pillar.transform.localScale;

        originalTreePosition = tree.transform.position;
        originalTreeScale = tree.transform.localScale;

        // capture changes in sliders and scale the objects they affect, accordingly
        pillarGrowthSlider.onValueChanged.AddListener(delegate { GrowObject(pillar, originalScale, originalPosition, pillarGrowthSlider); });
        treeGrowthSlider.onValueChanged.AddListener(delegate { GrowObject(tree, originalTreeScale, originalTreePosition, treeGrowthSlider); });

        runSimulationBtn.onClick.AddListener(TasksOnClick);

        rain.Stop();
        cloud.SetActive(false);

    }

   
    void Update()
    {
        //continuously display the values of each slider

        growthInfo.text = "Pillar Growth: " + pillarGrowthSlider.value.ToString();
        setGoal.text = "Pillar Growth Goal: " + goalSetterSlider.value.ToString();
        treeGrowthInfo.text = "Tree Growth: " + treeGrowthSlider.value.ToString();
        treeWaterGoal.text = "Water Goal: " + treeWaterGoalSlider.value.ToString();
    }

    void GrowObject(GameObject obj, Vector3 objOriginalScale, Vector3 objOriginalPosition, Slider growthSlider)
    {
        obj.transform.localScale = objOriginalScale + new Vector3(0, growthSlider.value, 0);

        //prevent scaling under ground plane, by moving the object upwards as it scales
        //This is NOT an elegant solution, but a quick fix!! - with some minor side effects
        obj.transform.position = objOriginalPosition + new Vector3(0, growthSlider.value, 0);
     }

    IEnumerator ScaleOverTime(float time, GameObject obj, Vector3 objOriginalScale, Vector3 objOriginalPosition, float factor)
    {
        // start rain if the object is tree
        Debug.Log(obj.name);
       
        //NOTE: There is a minor bug, that makes it rain even when the user
        //does not select the tree - FIX IT :)
        if (obj.name == "Fir_Tree")
        {
            Debug.Log(obj.name);
            cloud.SetActive(true);
            rain.Play();
        }

        // scales an object over time, using values set by the user with the slider

        Vector3 destinationScale = objOriginalScale + new Vector3(0, factor, 0);
        Vector3 destinationPosition = objOriginalPosition + new Vector3(0, factor, 0);

        float currentTime = 0.0f;
        
        do
        {
            obj.transform.localScale = Vector3.Lerp(objOriginalScale, destinationScale, currentTime / time);

            //prevent scaling under ground plane, by moving the object upwards as it scales
            obj.transform.position = Vector3.Lerp(objOriginalPosition, destinationPosition, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    void TasksOnClick()
    {
        // executed when the "Run Simulation" button is clicked
        cloud.SetActive(false);
        StartCoroutine(ScaleOverTime(2, pillar, originalScale, originalPosition, goalSetterSlider.value));
        StartCoroutine(ScaleOverTime(2, tree, originalTreeScale, originalTreePosition, treeWaterGoalSlider.value));
    }
}
