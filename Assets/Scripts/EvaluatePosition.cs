using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatePosition : MonoBehaviour
{
    public Button btn;
    public Text objectPositionsX;
    public Text objectPositionsY;
    public Text objectPositionsZ;
    public Text challenge;

    private float delta;
    private string relation;

    
    void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
        objectPositionsX.text = "X: ";
        objectPositionsY.text = "Y: ";
        objectPositionsZ.text = "Z: ";
        GenerateChallenge();
    }

    private void Update()
    {
        
    }

    void TaskOnClick()
    {
        objectPositionsX.text = "X: " + LogicalExpression("x", "Cube", "Sphere") + " AND " + LogicalExpression("x", "Sphere", "Cylinder");
        objectPositionsY.text = "Y: " + LogicalExpression("y", "Cube", "Sphere") + " AND " + LogicalExpression("y", "Sphere", "Cylinder");
        objectPositionsZ.text = "Z: " + LogicalExpression("z", "Cube", "Sphere") + " AND " + LogicalExpression("z", "Sphere", "Cylinder");
    }

    Vector3 getObjPos(string obj)
    {
        GameObject theObj = GameObject.Find(obj);
        return theObj.GetComponent<Transform>().position;
    }
  
    string LogicalExpression(string axis, string obj1, string obj2)
    {
        Vector3 obj1Pos = getObjPos(obj1);
        Vector3 obj2Pos = getObjPos(obj2);
        
        switch (axis)
        {
            case "x":
                delta = obj1Pos.x - obj2Pos.x;
                relation = " more then ";
                break;
            case "y":
                delta = obj1Pos.y - obj2Pos.y;
                relation = " on top of ";
                break;
            case "z":
                delta = obj2Pos.z - obj1Pos.z;
                relation = " in front of ";
                break;
        }

        if (delta > 0f)
            return obj1 + relation + obj2;
        else
            return obj2 + relation + obj1;
    }
    void GenerateChallenge()
    {
        List<string> objNames = new List<string>();
        List<string> positions = new List<string>();


        objNames.Add("Cube");
        objNames.Add("Sphere");
        objNames.Add("Cylinder");

        positions.Add("more then");
        positions.Add("in front of");
        positions.Add("on top of");

        //Select two random objects
        string randomObject1 = objNames[Random.Range(0, objNames.Count)];
        string randomObject2 = objNames[Random.Range(0, objNames.Count)];
        while (randomObject1 == randomObject2) randomObject2 = objNames[Random.Range(0, objNames.Count)];

        string randomPosition = positions[Random.Range(0, positions.Count)];

        challenge.text = randomObject1 + " " + randomPosition + " " + randomObject2;

    }

    bool VerifyPositions()
    {
        // Your code for the class activity goes here

        return true;
    }
}
