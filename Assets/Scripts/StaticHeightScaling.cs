/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Cybershoes;

/// <summary>
/// Example Implementation of player movement class using Cybershoes
/// Use as reference for own implementation
/// </summary>
public class StaticHeightScaling : MonoBehaviour
{
    private GameObject xrCamera;
    private UnityEngine.XR.InputDevice centerEyeDevice;

    private bool rotate = true;
    
    // Start is called before the first frame update
    void Start()
    {
        xrCamera = GameObject.Find("XRRig");
        centerEyeDevice = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
    }

    // Update is called once per frame
    void Update()
    {
        // Apply movement to camera.
        xrCamera.transform.Translate(GetCybershoesInput());

        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if(leftHandDevices.Count == 1 || rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice leftDevice = leftHandDevices[0];
            UnityEngine.XR.InputDevice rightDevice = rightHandDevices[0];
            Vector2 leftInputVector = Vector2.zero;
            Vector2 rightInputVector = Vector2.zero;
            bool aButtonPressed = false;
            bool bButtonPressed = false;
            if (leftDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out leftInputVector))
            {
                Quaternion hmdRotation;
                // Get rotation of hmd, restrict to only y-axis, let player movement follow hmd rotation.
                if (centerEyeDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeRotation, out hmdRotation))
                {
                    hmdRotation.x = 0;
                    hmdRotation.z = 0;
                    xrCamera.transform.Translate(hmdRotation * new Vector3(leftInputVector.x * Time.deltaTime * 10, 0, leftInputVector.y * Time.deltaTime * 10));
                }
                else
                {
                    Debug.Log("No hmd found!");
                    return;
                }
            }
            // Stick input on right VR-controller rotates camera 45 degrees at a time.
            if (rightDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out rightInputVector))
            { 
                float horizontalInput = rightInputVector.x;
                if (rotate && horizontalInput >= 0.8f) // Include deadzone to rotation to the right.
                {
                    xrCamera.transform.Rotate(new Vector3(0, 45, 0));
                    rotate = false;
                }
                else if (rotate && horizontalInput <= -0.8f) // Include deadzone to rotation to the left.
                {
                    xrCamera.transform.Rotate(new Vector3(0, -45, 0));
                    rotate = false;
                }
                else if (horizontalInput < 0.8f && horizontalInput > -0.8f) // Only rotate if stick is not at maximum, otherwise rotation would be constant.
                {
                    rotate = true;
                }
            }
            Vector3 cameraPosition = xrCamera.transform.localPosition;
            if (rightDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out aButtonPressed) && aButtonPressed)
            {
                xrCamera.transform.localPosition = new Vector3(cameraPosition.x, 0.3f, cameraPosition.z);
            }
            if (rightDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bButtonPressed) && bButtonPressed)
            {
                xrCamera.transform.localPosition = new Vector3(cameraPosition.x, 0, cameraPosition.z);
            }
        }
        else if(leftHandDevices.Count > 1 && rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one set of hands!");
        }
    }

    /// <summary>
    /// Returns a vector detailing the x and z axes player movement according to cybershoes movement.
    /// Call per frame to constanly update player movement.
    /// </summary>
    /// <returns>characterMovement usable to update position of player camera or player controller</returns>
    private Vector3 GetCybershoesInput()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("No gamepad found!");
            return Vector3.zero;
        }
        Vector2 shoeMovement = new Vector2(gamepad.leftStick.x.ReadValue(), gamepad.leftStick.y.ReadValue());
        Quaternion hmdRotation;
        if (centerEyeDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeRotation, out hmdRotation))
        {
            hmdRotation.x = 0;
            hmdRotation.z = 0;
            Vector2 adjustedShoeMovement = CybershoesInput.GetRotatedShoeVector(hmdRotation, shoeMovement);
            Vector3 characterMovement = hmdRotation * new Vector3(adjustedShoeMovement.x * Time.deltaTime * 2, 0, adjustedShoeMovement.y * Time.deltaTime * 2);
            return characterMovement;
        }
        else 
        {
            Debug.Log("No hmd found");
            return Vector3.zero;
        }
    }   
}
*/