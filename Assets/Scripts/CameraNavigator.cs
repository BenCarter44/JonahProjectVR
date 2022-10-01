using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class CameraNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    public float moveSpeed;
	public float rotateSpeed;
	
	private float rotation;
    private float rotationDEG;
	
	private InputDevice leftDevice;
	private InputDevice rightDevice;
	

    void Start()
    {
        rotationDEG = 0.0f;
        mainCamera.transform.eulerAngles = new Vector3(0, rotationDEG, 0);
        rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
		var leftHandDevices = new List<InputDevice>();
		var rightHandDevices = new List<InputDevice>();
		InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);
		InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
		leftDevice = leftHandDevices[0];
		rightDevice = rightHandDevices[0];
    }

    // Update is called once per frame  // axises are different. 0 deg is up.
    void Update()
    {
		Vector2 axisLeft;
		bool getValue = leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis,out axisLeft);
		Vector2 axisRight;
		bool getValueR = rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis,out axisRight);
		
        if (getValueR && axisRight.y > 0.5f)
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation) * moveSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation) * moveSpeed);
            mainCamera.transform.position = target;
        }
        if (getValueR && axisRight.y < -0.5f)
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x - Mathf.Sin(rotation) * moveSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z - Mathf.Cos(rotation) * moveSpeed);
            mainCamera.transform.position = target;
        }
        if (getValueR && axisRight.x < -0.5f)
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation - Mathf.PI / 2.0f) * moveSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation - Mathf.PI / 2.0f) * moveSpeed);
            mainCamera.transform.position = target;
        }
        if (getValueR && axisRight.x > 0.5f)
        {
            Vector3 target = new Vector3(mainCamera.transform.position.x + Mathf.Sin(rotation + Mathf.PI / 2.0f) * moveSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z + Mathf.Cos(rotation + Mathf.PI / 2.0f) * moveSpeed);
            mainCamera.transform.position = target;
        }
        if (getValue && axisLeft.x < -0.5f)
        {
            rotationDEG = rotationDEG - rotateSpeed;
            rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
            mainCamera.transform.Rotate(0.0f, -rotateSpeed, 0.0f);
        }
        if (getValue && axisLeft.x > 0.5f)
        {
            rotationDEG = rotationDEG + rotateSpeed;
            rotation = (2f * Mathf.PI / 360.0f) * (float)rotationDEG;
            mainCamera.transform.Rotate(0.0f, rotateSpeed, 0.0f);
        }
      /*  if (getValueR && axisRight.y > 0.5f)
        {
            mainCamera.transform.Rotate(rotateSpeed, 0.0f, 0.0f);
        }
        if (getValueR && axisRight.y < -0.5f)
        {
            mainCamera.transform.Rotate(-rotateSpeed, 0.0f, 0.0f);
        }
*/

    }
}
