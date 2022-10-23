using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using TMPro;

public class CameraNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    public float moveSpeed;
	public float rotateSpeed;
	public float deadZone;
    public TextMeshPro debugger;
	public GameObject camRaw;
	
	private InputDevice leftDevice;
	private InputDevice rightDevice;
    
	
    private VRCustomInputManager vr;

    void Start()
    {
      //  rotationDEG = 0.0f;
       // float rad = mainCamera.transform.eulerAngles.y;
      //  rotation = (rad / ((2f * Mathf.PI)) * 360.0f;
        
		vr = new VRCustomInputManager();
        vr.deadZone = deadZone;
      //  debugger = GameObject.Find("Debugger").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame  // axises are different. 0 deg is up.
    void Update()
    {
		bool err = false;
        Vector2 axisLeft = vr.getLJoystick;
		err = err || vr.isError;
        Vector2 axisRight = vr.getRJoystick;
		err = err || vr.isError;
        if(debugger)
        debugger.text = "IsError!";
     
        if(err)
        {
            debugger.text = "IsError!";
            return;
        }
        else
        {
          //  debugger.text = "NoE";
        }
        float rotationChange = axisLeft.x * Time.deltaTime * rotateSpeed;
        float radi = (2f * Mathf.PI / 360.0f) * (float)rotationChange;
        //mainCamera.transform.Rotate(0.0f, -radi, 0.0f);
        
      //  float rad = camRaw.transform.eulerAngles.y;
        float rad = InputTracking.GetLocalRotation(XRNode.CenterEye).eulerAngles.y; // gets the angles of the headset.
        rad = 90.0f - rad;
        //   float rad =  Mathf.PI / 4;
        debugger.text = "" + rad;
        float rotation = (rad * (2f * Mathf.PI)) / 360.0f;
        float moveX = axisRight.x * moveSpeed * Time.deltaTime;
        float moveY = axisRight.y * moveSpeed * Time.deltaTime;
        
        // using a rotating a vector formula

        Vector3 comboDir = new Vector3(Mathf.Cos(rad) * moveX - Mathf.Sin(rad) * moveY,0.0f, Mathf.Sin(rad) * moveX + Mathf.Cos(rad) * moveY);
        debugger.text = "" + rad;
        mainCamera.transform.Translate(comboDir);

        /*
           Vector3 gamepad3D = new Vector3(gamepad.leftStick.x.ReadValue(), 0.0, gamepad.leftStick.y.ReadValue()); // for the future with cybershoes.
            mainCamera.transform.Translate(gamepad3D * Time.deltaTime * moveSpeed);
         
        */


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
