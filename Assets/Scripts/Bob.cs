using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bob : MonoBehaviour
{
 
 
 
   public float heightMax = 1.0f;          // Maximum up and down
   public float sideMax = 25.0f;         // Maximum rotation side to side
   public float frontMax = 10.0f;         // Maximum rotation front to back
   public float heightSpeed = 0.5f;          // Speed of waves
   public float rockSpeed = 1.0f;          // Speed of rocking
   public float speedVariable = 0.2f;          // Variable of speeds.
   public float curSideSpeed;
   public float curFrontSpeed;
   public float curHeightSpeed;
   public float sideVariable;
   public float frontVariable;
   public float heightVariable;
   public int curSideMultiplier = 1;
   public int curFrontMultiplier = 1;
   public int curHeightMultiplier = 1;
   public Vector3 startPosition;
   public Vector3 startRotation;
   public float curSideDif;
   public float curFrontDif;
 
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
        sideVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        frontVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        heightVariable = heightSpeed + Random.Range(-speedVariable, speedVariable);
    }
 
    void Update()
    {
        // Height of boat
        transform.position.Set(transform.position.x, transform.position.y + Time.deltaTime * heightVariable * curHeightMultiplier, transform.position.z);
 
        // Side to side rocking
        curSideDif += Time.deltaTime * sideVariable * curSideMultiplier;
        // Front to Back rocking
        curFrontDif += Time.deltaTime * frontVariable * curFrontMultiplier;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(startRotation.x + curSideDif, transform.eulerAngles.y, startRotation.z + curFrontDif)),0.01f);
 
 
 
 
        // Check Max
        if (transform.position.y >= startPosition.y + heightMax)
        {
            curHeightMultiplier = -1;
            heightVariable = heightSpeed + Random.Range(-speedVariable, speedVariable);
        }
        if (transform.position.y <= startPosition.y - heightMax)
        {
            curHeightMultiplier = 1;
            heightVariable = heightSpeed + Random.Range(-speedVariable, speedVariable);
        }
        if (curSideDif >= sideMax)
        {
            curSideMultiplier = -1;
            sideVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        }
        if (curSideDif <= -sideMax)
        {
            curSideMultiplier = 1;
            sideVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        }
        if (curFrontDif >= frontMax)
        {
            curFrontMultiplier = -1;
            frontVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        }
        if (curFrontDif <= -frontMax)
        {
            curFrontMultiplier = 1;
            frontVariable = rockSpeed + Random.Range(-speedVariable, speedVariable);
        }
    }
}