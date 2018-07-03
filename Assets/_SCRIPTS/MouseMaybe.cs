using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Leap;
using Leap.Unity;

public class MouseMaybe : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    public int XPos = 30, YPos = 1000;

    public int ScreenWidth = Screen.width;
    public int ScreenHeight = Screen.height;
    public HandModelBase PointerHand;

    Vector3 _palmPosition;
    Vector3 _palmDirection;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Screen Width : " + ScreenWidth);
        Debug.Log("Screen Height : " + ScreenHeight);
    }

    // Update is called once per frame
    void Update()
    {
        _palmPosition = PointerHand.GetLeapHand().PalmPosition.ToVector3();
        _palmDirection = PointerHand.GetLeapHand().Direction.ToVector3();

        Debug.DrawRay(_palmPosition, _palmDirection);
        //SetCursorPos(XPos, YPos); //Call this when you want to set the mouse position
    }
}