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
    public TextMeshPro debugger2;
    public TextMeshPro debugger3;
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
        bool resetView = vr.buttonB;
        err = err || vr.isError;
        if (debugger)
        {
            debugger.text = "IsError!";
        }
     
        if(err)
        {
            debugger.text = "IsError!";
            return;
        }
        else
        {
            //  debugger.text = "NoE";
            debugger2.text = "X: " + axisLeft.x;
            debugger3.text = "Y: " + axisLeft.y;
        }
        if(resetView)
        {
            mainCamera.transform.position = new Vector3(-43f, 0.8f, 120f);
        }
       
       
        //mainCamera.transform.Rotate(0.0f, -radi, 0.0f);
        Vector3 plain1 = new Vector3(axisRight.x * moveSpeed * Time.deltaTime, 0.0f, axisRight.y * moveSpeed * Time.deltaTime);
        //  float rad = camRaw.transform.eulerAngles.y;
        float rad = vr.getViewAngle.eulerAngles.y; //InputTracking.GetLocalRotation(XRNode.CenterEye).eulerAngles.y; // gets the angles of the headset.
        rad = 180.0f - rad;
        //  float rad =  Mathf.PI / 4;
        debugger.text = "" + rad;
        float rotation = (rad * (2f * Mathf.PI)) / 360.0f;
       // Vector3 rotationAdjusted
        
        // using a rotating a vector formula
        
        Vector3 comboDir = new Vector3(Mathf.Cos(rotation) * plain1.x - Mathf.Sin(rotation) * plain1.z,0.0f, Mathf.Sin(rotation) * plain1.x + Mathf.Cos(rotation) * plain1.z);
        mainCamera.transform.Translate(comboDir * -1);
        
       // Vector3 plain = new Vector3(axisLeft.x * moveSpeed * Time.deltaTime, 0.0f, axisLeft.y * moveSpeed * Time.deltaTime); // plain!
       // mainCamera.transform.position = mainCamera.transform.position + plain; // (plain);


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
