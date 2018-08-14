using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Leap;
using Leap.Unity;
using UnityEngine.Assertions;
using UnityEngine.Experimental.UIElements;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Assertions.Must;


//[ExecuteInEditMode]
public class MouseMaybe : Detector
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);

    private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
    private const uint MOUSEEVENTF_LEFTUP = 0x04;
    private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const uint MOUSEEVENTF_RIGHTUP = 0x10;

    //[DllImport("user32.dll")]
    //static extern bool SetCursorPos(int x, int y);

    public int DebugScreenWidth = 1920;
    public int DebugScreenHeight = 1080;
    public HandModelBase PointerHand;
    Hand _hand;
    public Camera Cam;

    Vector3 _palmPosition;
    Vector3 _palmDirection;


    public double OnDepth = .6;
    public double OffDepth = .5;

    // Update is called once per frame
    void Update()
    {
        if (PointerHand.isActiveAndEnabled & Cam != null)
        {
            Vector3 fingerTip = PointerHand.GetLeapHand().GetIndex().TipPosition.ToVector3();
            Vector3 screenVector3 = Cam.WorldToScreenPoint(fingerTip);

            float xPos = MapToRange(screenVector3.x, 0, Cam.pixelWidth, 0, DebugScreenWidth);
            float yPos = MapToRange(Cam.pixelHeight - screenVector3.y, 0, Cam.pixelHeight, 0, DebugScreenHeight);

            SetCursorPos((int) xPos, (int) yPos); // Call this when you want to set the mouse position

            if (screenVector3.z >= OnDepth)
            {
                Activate();
            }

            if (screenVector3.z < OffDepth)
            {
                Deactivate();
            }
        }
    }

    private void OnValidate()
    {
        if (Cam != null)
        {
            Assert.IsTrue(MapToRange(0, 0, Cam.pixelWidth, 0, DebugScreenWidth) == 0);
            Assert.IsTrue(MapToRange(Cam.pixelWidth, 0, Cam.pixelWidth, 0, DebugScreenWidth) == DebugScreenWidth);
        }
    }

    int MapToRange(float input, int inputRangeStart, int inputRangeEnd, int outputRangeStart, int outputRangeEnd)
    {
        var inputRatio = input / inputRangeEnd;
        var output = inputRatio * outputRangeEnd;

        //var slope = (outputRangeEnd - outputRangeStart) / (inputRangeEnd - inputRangeStart);
        //var output = outputRangeStart + slope * (input - inputRangeStart);
//        Debug.Log("input: " + input +
//                  " inputRangeStart: " + inputRangeStart +
//                  " inputRangeEnd: " + inputRangeEnd +
//                  " outputRangeStart: " + outputRangeStart +
//                  " outputRangeEnd: " + outputRangeEnd +
//                  " inputRatio: " + inputRatio +
//                  //" slope: " + slope +
//                  " output: " + output);

        return (int) output;
    }

    public void SendMouseRightclick(uint x, uint y)
    {
        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr) 0);
    }

//    void SendMouseDoubleClick(uint x, uint y)
//    {
//        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, (UIntPtr) 0);
//
//        //Thread.Sleep(150);
//        //yield return new WaitForSecondsRealtime(5);
//
//        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, (UIntPtr) 0);
//    }

//    void SendMouseRightDoubleClick(uint x, uint y)
//    {
//        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr) 0);
//
//        //Thread.Sleep(150);
//
//        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, (UIntPtr) 0);
//    }

    public void SendMouseDown()
    {
        //Debug.Log("Mouse Down");
        mouse_event(MOUSEEVENTF_LEFTDOWN, 50, 50, 0, (UIntPtr) 0);
    }

    public void SendMouseUp()
    {
        //Debug.Log("Mouse Up");
        mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, (UIntPtr) 0);
    }
}