using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    private float rotation;

    void Start()
    {
        rotation = -90.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + 1.0f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = target;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x - 1.0f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = target;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z - 1.0f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + 1.0f, mainCamera.transform.position.y, mainCamera.transform.position.z + 1.0f);
            mainCamera.transform.position = target;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotation = rotation - 0.01f;
            mainCamera.transform.Rotate(0.0f, rotation, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotation = rotation + 0.01f;
            mainCamera.transform.Rotate(0.0f, rotation, 0.0f);
        }


    }
}
