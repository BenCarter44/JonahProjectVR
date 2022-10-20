using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

// https://docs.unity3d.com/Manual/xr_input.html

public class CustomInputManagerVR
{
    private InputDevice leftDevice;
	private InputDevice rightDevice;
    private InputDevice headsetDevice;
    public float deadZone
    {
        get; set;
    }

    public float batteryLevel
    {
        get
        {
            return getRawF(headsetDevice,CommonUsages.batteryLevel);
        }
    }
    public bool userActive
    {
        get
        {
            return getRawB(headsetDevice,CommonUsages.userPresence);
        }
       // private set;
    }
    
    private bool err;
    public bool isError
    {
        get
        {
            return err;
        }
     //   private set;
    }
    public CustomInputManagerVR()
    {
        var allDev = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(allDev);
        foreach (var device in allDev)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }

        var leftHandDevices = new List<InputDevice>();
		var rightHandDevices = new List<InputDevice>();
        var headDevices = new List<InputDevice>();
		InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);
		InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
        InputDevices.GetDevicesWithRole(InputDeviceRole.Generic, headDevices);
		leftDevice = leftHandDevices[0];
		rightDevice = rightHandDevices[0];
        headsetDevice = headDevices[0];
    }
    private Vector2 getRawV(InputDevice dev,InputFeatureUsage<Vector2> ug)
    {
        Vector2 ans;
        err = dev.TryGetFeatureValue(ug,out ans);
        return ans;
    }
    private float getRawF(InputDevice dev,InputFeatureUsage<float> ug)
    {
        float ans;
        err = dev.TryGetFeatureValue(ug,out ans);
        return ans;
    }
    private bool getRawB(InputDevice dev,InputFeatureUsage<bool> ug)
    {
        bool ans;
        err = dev.TryGetFeatureValue(ug,out ans);
        return ans;
    }
    public Vector2 getLJoystick
    {
        get
        {
            Vector2 ans = getRawV(leftDevice,CommonUsages.primary2DAxis);
            if(Mathf.Abs(ans.x) < deadZone)
            {
                ans.x = 0.0f;
            }
            if(Mathf.Abs(ans.y) < deadZone)
            {
                ans.y = 0.0f;
            }
            return ans;
        }
   //     private set;
    }
    public Vector2 getRJoystick
    {
        get
        {
            Vector2 ans = getRawV(rightDevice,CommonUsages.primary2DAxis);
            if(Mathf.Abs(ans.x) < deadZone)
            {
                ans.x = 0.0f;
            }
            if(Mathf.Abs(ans.y) < deadZone)
            {
                ans.y = 0.0f;
            }
            return ans;
        }
   //     private set;
    }
    public float getLTrigger
    {
        get
        {
            return getRawF(leftDevice,CommonUsages.trigger);
        }
  //      private set;
    }
    public float getRTrigger
    {
        get
        {
            return getRawF(rightDevice,CommonUsages.trigger);
        }
   //     private set;
    }
    public bool buttonA
    {
        get
        {
            return getRawB(rightDevice,CommonUsages.primaryButton);
        }
   //     private set;
    }
    public bool buttonB
    {
        get
        {
            return getRawB(rightDevice,CommonUsages.secondaryButton);
        }
   //     private set;
    }
    public bool buttonX
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.primaryButton);
        }
    //    private set;
    }
    public bool buttonY
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.secondaryButton);
        }
    //    private set;
    }
    public float getLHolding
    {
        get
        {
            return getRawF(leftDevice,CommonUsages.grip);
        }
    //    private set;
    }
    public float getRHolding
    {
        get
        {
            return getRawF(rightDevice,CommonUsages.grip);
        }
    //    private set;
    }
    public bool startButton
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.menuButton);
        }
     //   private set;
    }
    public bool getLTriggerButton
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.triggerButton);
        }
     //   private set;
    }
    public bool getRTriggerButton
    {
        get
        {
            return getRawB(rightDevice,CommonUsages.triggerButton);
        }
    //    private set;
    }
    public bool getLJoystickPress
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.primary2DAxisClick);
        }
     //   private set;
    }
    public bool getRJoystickPress
    {
        get
        {
            return getRawB(rightDevice,CommonUsages.primary2DAxisClick);
        }
     //   private set;
    }
    public bool getLJoystickTouch
    {
        get
        {
            return getRawB(leftDevice,CommonUsages.primary2DAxisTouch);
        }
     //   private set;
    }
    public bool getRJoystickTouch
    {
        get
        {
            return getRawB(rightDevice,CommonUsages.primary2DAxisTouch);
        }
    //    private set;
    }

}
