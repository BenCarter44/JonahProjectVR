using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using Cybershoes;

public class CameraNavigator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    public float moveSpeed;
    public float walkSpeed;
	public float rotateSpeed;
	public float deadZone;
    private float walkHold;
   /* public TextMeshPro debugger;
    public TextMeshPro debugger2;
    public TextMeshPro debugger3;
   */
   // public GameObject camRaw;
	
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
        if (vr == null)
        {
            Debug.Log("No VR Headset!");
            return;
        }
        //  debugger = GameObject.Find("Debugger").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame  // axises are different. 0 deg is up.


    void Update()
    {
        if (vr == null)
        {
            //   Debug.Log("No VR Headset!");
         //   mainCamera.transform.Translate(new Vector3(0,0,-1.0f * Time.deltaTime * moveSpeed));
            return;
        }
        bool err = false;
        Vector2 axisLeft = vr.getLJoystick;
		err = err || vr.isError;
        Vector2 axisRight = vr.getRJoystick;
		err = err || vr.isError;
        bool resetView = vr.buttonB;
        err = err || vr.isError;
      /*  if (debugger)
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
      */
        if(resetView)
        {
           // mainCamera.transform.position = new Vector3(-138.6f, 0.8f, 23.3f);
            walkHold = 2 * walkSpeed;
        }
        else
        {
            walkHold = walkSpeed;
        }
        /*
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            mainCamera.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mainCamera.transform.Translate(new Vector3(-1.0f * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mainCamera.transform.Translate(new Vector3(0.0f,0.0f,-1.0f * moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mainCamera.transform.Translate(new Vector3(0.0f,0.0f,moveSpeed * Time.deltaTime));
        }
        */


        //mainCamera.transform.Rotate(0.0f, -radi, 0.0f);
        Vector3 plain1 = new Vector3(axisRight.x * moveSpeed * Time.deltaTime, 0.0f, axisRight.y * moveSpeed * Time.deltaTime);
        //  float rad = camRaw.transform.eulerAngles.y;
        float rad = vr.getViewAngle.eulerAngles.y; //InputTracking.GetLocalRotation(XRNode.CenterEye).eulerAngles.y; // gets the angles of the headset.
        rad = 180.0f - rad;
        //  float rad =  Mathf.PI / 4;
      //  debugger.text = "" + rad;
        float rotation = (rad * (2f * Mathf.PI)) / 360.0f;
       // Vector3 rotationAdjusted
        
        // using a rotating a vector formula
        
        Vector3 comboDir = new Vector3(Mathf.Cos(rotation) * plain1.x - Mathf.Sin(rotation) * plain1.z,0.0f, Mathf.Sin(rotation) * plain1.x + Mathf.Cos(rotation) * plain1.z);
        mainCamera.transform.Translate(comboDir * -1);
    //    Debug.Log("P: " + mainCamera.transform.position.x + " : " + mainCamera.transform.position.z);

       // Vector3 plain = new Vector3(axisLeft.x * moveSpeed * Time.deltaTime, 0.0f, axisLeft.y * moveSpeed * Time.deltaTime); // plain!
       // mainCamera.transform.position = mainCamera.transform.position + plain; // (plain);


        
        //   Vector3 gamepad3D = new Vector3(gamepad.leftStick.x.ReadValue(), 0.0, gamepad.leftStick.y.ReadValue()); // for the future with cybershoes.
           Vector3 gamepad3D = GetCybershoesInput();
            mainCamera.transform.Translate(gamepad3D * Time.deltaTime * walkHold);
         
        


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
    private Vector3 GetCybershoesInput()
    {
        var gamepad = UnityEngine.InputSystem.Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("No gamepad found!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return Vector3.zero;
        } 
        Vector2 shoeMovement = new Vector2(gamepad.leftStick.x.ReadValue(), gamepad.leftStick.y.ReadValue());
        Quaternion hmdRotation = vr.getViewAngle;
        
        hmdRotation.x = 0;
        hmdRotation.z = 0;
        Vector2 adjustedShoeMovement = CybershoesInput.GetRotatedShoeVector(hmdRotation, shoeMovement);
        Vector3 characterMovement = hmdRotation * new Vector3(adjustedShoeMovement.x, 0, adjustedShoeMovement.y);
        return characterMovement;
    }  
    public void OnSelectCar(XRBaseInteractor obj)
    {
        //obj.GameObject.
    }
}
