using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

// https://docs.unity3d.com/Manual/xr_input.html

public class VRCustomInputManager
{
    private InputDevice leftDevice;
	private InputDevice rightDevice;
    private InputDevice headsetDevice;
    private float deadZone;

    public float batteryLevel
    {
        get
        {
            return getRaw<float>(headsetDevice,CommonUsages.batteryLevel);
        }
        private set;
    }
    public float userActive
    {
        get
        {
            return getRaw<float>(headsetDevice,CommonUsages.userPresence);
        }
        private set;
    }
    private bool err;
    public bool isError
    {
        get
        {
            return err;
        }
        private set;
    }
    public VRCustomInputManager()
    {
        var allDev = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        foreach (var device in inputDevices)
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
    private T getRaw<T>(InputDevice dev,CommonUsages ug)
    {
        T ans;
        err = leftDevice.TryGetFeatureValue(ug,out ans);
        return ans;
    }
    public Vector2 getLJoystick
    {
        get
        {
            Vector2 ans = getRaw<Vector2>(leftDevice,CommonUsages.primary2DAxis);
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
        private set;
    }
    public Vector2 getRJoystick
    {
        get
        {
            Vector2 ans = getRaw<Vector2>(rightDevice,CommonUsages.primary2DAxis);
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
        private set;
    }
    public float getLTrigger
    {
        get
        {
            return getRaw<float>(leftDevice,CommonUsages.trigger);
        }
        private set;
    }
    public float getRTrigger
    {
        get
        {
            return getRaw<float>(rightDevice,CommonUsages.trigger);
        }
        private set;
    }
    public bool buttonA
    {
        get
        {
            return getRaw<bool>(rightDevice,CommonUsages.primaryButton);
        }
        private set;
    }
    public bool buttonB
    {
        get
        {
            return getRaw<bool>(rightDevice,CommonUsages.secondaryButton);
        }
        private set;
    }
    public bool buttonX
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.primaryButton);
        }
        private set;
    }
    public bool buttonY
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.secondaryButton);
        }
        private set;
    }
    public float getLHolding
    {
        get
        {
            return getRaw<float>(leftDevice,CommonUsages.grip);
        }
        private set;
    }
    public float getRHolding
    {
        get
        {
            return getRaw<float>(rightDevice,CommonUsages.grip);
        }
        private set;
    }
    public bool startButton
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.menuButton);
        }
        private set;
    }
    public bool getLTriggerButton
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.triggerButton);
        }
        private set;
    }
    public bool getRTriggerButton
    {
        get
        {
            return getRaw<bool>(rightDevice,CommonUsages.triggerButton);
        }
        private set;
    }
    public bool getLJoystickPress
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.primary2DAxisClick);
        }
        private set;
    }
    public bool getRJoystickPress
    {
        get
        {
            return getRaw<bool>(rightDevice,CommonUsages.primary2DAxisClick);
        }
        private set;
    }
    public bool getLJoystickTouch
    {
        get
        {
            return getRaw<bool>(leftDevice,CommonUsages.primary2DAxisTouch);
        }
        private set;
    }
    public bool getRJoystickTouch
    {
        get
        {
            return getRaw<bool>(rightDevice,CommonUsages.primary2DAxisTouch);
        }
        private set;
    }

}
