using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    private float rotation;
    private float rotationDEG;

    void Start()
    {
        rotationDEG = 0.0f;
        mainCamera.transform.eulerAngles = new Vector3(0, rotationDEG, 0);
        rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
    }

    // Update is called once per frame  // axises are different. 0 deg is up.
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation) * 0.02f, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation) * 0.02f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x - Mathf.Sin(rotation) * 0.02f, mainCamera.transform.position.y, mainCamera.transform.position.z - Mathf.Cos(rotation) * 0.02f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation - Mathf.PI / 2.0f) * 0.02f, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation - Mathf.PI / 2.0f) * 0.02f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation + Mathf.PI / 2.0f) * 0.02f, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation + Mathf.PI / 2.0f) * 0.02f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationDEG = rotationDEG - 0.1f;
            rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
            mainCamera.transform.Rotate(0.0f, -0.1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationDEG = rotationDEG + 0.1f;
            rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
            mainCamera.transform.Rotate(0.0f, 0.1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.Rotate(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.Rotate(-0.1f, 0.0f, 0.0f);
        }


    }
}
