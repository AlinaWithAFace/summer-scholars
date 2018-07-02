using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Utilities : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Returns whether or not the gesture has changed from the last time it was looked at,
    /// and changes the given ActionFlag's flag accordingly.
    ///
    /// For example, if the gesture for walk forward is detected, and the moveForward flag is false,
    /// you're not already walking forward, so change the flag to true and change the fact you changed the flag to true,
    /// but if the gesture for walk forward is detected and moveForward is true, you're already moving forward,
    /// so you can pretty much leave everything else as-is
    /// </summary>
    /// <param name="gestureDetected"></param>
    /// <param name="actionFlag"></param>
    /// <returns></returns>
    public static bool detectGestureChange(bool gestureDetected, ActionFlag.Flags actionFlag)
    {
        int flagValueIndex = (int) actionFlag;
        bool gestureChangedFlag = false;

        if (gestureDetected)
        {
            if (!ActionFlag.flagValues[flagValueIndex])
            {
                gestureChangedFlag = true;
            }

            ActionFlag.flagValues[flagValueIndex] = true;
        }
        else
        {
            if (ActionFlag.flagValues[flagValueIndex])
            {
                gestureChangedFlag = true;
            }

            ActionFlag.flagValues[flagValueIndex] = false;
        }

        return gestureChangedFlag;
    }

    /// <summary>
    /// Given a boolean, try to push a button based on whether said boolean is true or false.
    /// If the bool is true, try to push the button, if it's false, try to release the button
    /// </summary>
    /// <param name="actionFlag"></param>
    /// <param name="keyCode"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void tryToPressAButton(ActionFlag.Flags actionFlag, KeyCode keyCode)
    {
        // Old Java Code
//        Robot robot;
//        try {
//            robot = new Robot();
//            if (actionFlag.flag) {
//                System.out.println("Press Key " + keyEventCode);
//                robot.keyPress(keyEventCode);
//            } else {
//                System.out.println("Release Key " + keyEventCode);
//                robot.keyRelease(keyEventCode);
//            }
//        } catch (AWTException e) {
//            e.printStackTrace();
//        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Similar to tryToPressAButton, but rather than potentially pressing or releasing it,
    /// this simply presses and releases the key if the related boolean is positive and does nothing if it's negative
    /// </summary>
    /// <param name="actionFlag"></param>
    /// <param name="keyCode"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void tryToTapAButton(ActionFlag.Flags actionFlag, KeyCode keyCode)
    {
        // Old Java Code
//        Robot robot;
//        try {
//            robot = new Robot();
//            if (actionFlag.flag) {
//                System.out.println("Tap " + keyEventCode);
//                robot.keyPress(keyEventCode);
//                robot.keyRelease(keyEventCode);
//            }
//        } catch (AWTException e) {
//            e.printStackTrace();
//        }

        throw new NotImplementedException();
    }

    public static void tryToMouse(ActionFlag.Flags actionFlag, MouseButton mouseEventCode)
    {
        // Old Java Code
//        Robot robot;
//        try {
//            robot = new Robot();
//            if (actionFlag.flag) {
//                robot.mousePress(mouseEventCode);
//            } else {
//                robot.mouseRelease(mouseEventCode);
//            }
//        } catch (AWTException e) {
//            e.printStackTrace();
//        }

        throw new NotImplementedException();
    }
}