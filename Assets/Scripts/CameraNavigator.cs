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
        float rad = InputTracking.GetLocalRotation(XRNode.CenterEye).eulerAngles.y;
        //   float rad =  Mathf.PI / 4;
        debugger.text = "" + rad;
        float rotation = (rad * (2f * Mathf.PI)) / 360.0f;
        float moveX = axisRight.x * moveSpeed * Time.deltaTime;
        float moveY = axisRight.y * moveSpeed * Time.deltaTime * -1;
        Vector3 ct = new Vector3(moveX,0,0);
        Vector3 ct2 = new Vector3(0,0,moveY); // local scale
        Vector3 combo = ct + ct2;
        Vector3 comboDir = new Vector3(Mathf.Sin(rad) * combo.x,0,Mathf.Cos(rad) * combo.z);
        debugger.text = "" + rad + "," + (Mathf.Sin(rad) * combo.x);
        Vector3 final = mainCamera.transform.position + comboDir;
        mainCamera.transform.position = final;
		
        
        
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
