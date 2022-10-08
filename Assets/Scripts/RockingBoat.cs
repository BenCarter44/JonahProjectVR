using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPosition : MonoBehaviour
{
    public Vector3 positionToMoveTo = new Vector3(0,0,0);
    void Start()
    {
        StartCoroutine(LerpPosition(positionToMoveTo, 5));
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.eulerAngles;
        while (time < duration)
        {
            transform.eulerAngles = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.eulerAngles = targetPosition;
    }
}
