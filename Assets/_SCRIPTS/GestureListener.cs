using System;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityScript.Steps;

public class NewBehaviourScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Hand leftHand = Hands.Left;
        Hand rightHand = Hands.Right;

        HandleBioticOrbGesture(leftHand, rightHand);

        HandleLeftBioticGraspGesture(leftHand);
        HandleCoalescenceGesture(leftHand);
        HandleFadeGesture(leftHand);
        HandleWaveGesture(leftHand);

        HandleRightBioticGraspGesture(rightHand);
        HandleMeleeGesture(rightHand);
    }


    private const double FingerPointUpNum = .5;
    private const int FingerNum = 5;

    /// <summary>
    /// presses the E button if BioticOrbGesture is detected
    /// </summary>
    /// <param name="leftHand"></param>
    /// <param name="rightHand"></param>
    private void HandleBioticOrbGesture(Hand leftHand, Hand rightHand)
    {
        bool gestureOccurring = BioticOrbGestureDetected(leftHand, rightHand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.BioticOrb);
        if (gestureFlag)
        {
            Utilities.tryToTapAButton(ActionFlag.Flags.BioticOrb, KeyCode.E);
        }
    }

    /// <summary>
    /// detects whether all fingers of both hands are forward (think a T-Rex)
    /// </summary>
    /// <param name="leftHand"></param>
    /// <param name="rightHand"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool BioticOrbGestureDetected(Hand leftHand, Hand rightHand)
    {
        double bioticOrbFingerDirection = -.8;
        int bioticOrbFingerCount = 8;

        Hand[] hands = {leftHand, rightHand};

        int fingerUpCount = 0;
        foreach (Hand hand in hands)
        {
            foreach (Finger finger in hand.Fingers)
            {
                if (finger.Type != Finger.FingerType.TYPE_THUMB)
                {
                    if (finger.Direction.z <= bioticOrbFingerDirection)
                    {
                        fingerUpCount++;
                    }
                }
            }
        }

        if (fingerUpCount >= bioticOrbFingerCount)
        {
            //System.out.println("All 10 fingers facing forward?");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Presses v if the given hand is balled into a fist
    /// </summary>
    /// <param name="hand"></param>
    private void HandleMeleeGesture(Hand hand)
    {
        bool gestureOccuring = FistGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccuring, ActionFlag.Flags.Melee);
        if (gestureFlag)
        {
            Utilities.tryToTapAButton(ActionFlag.Flags.Melee, KeyCode.V);
        }
    }

    /// <summary>
    /// Hits the right mouse button if the gesture is detected
    /// </summary>
    /// <param name="hand"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void HandleRightBioticGraspGesture(Hand hand)
    {
        bool gestureOccurring = BioticGraspGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.RightBioticGrasp);
        if (gestureFlag)
        {
            Utilities.tryToMouse(ActionFlag.Flags.RightBioticGrasp, MouseButton.RightMouse);
        }
    }

    /// <summary>
    /// Presses B if the gesture is detected
    /// </summary>
    /// <param name="hand"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void HandleWaveGesture(Hand hand)
    {
        bool gestureOccurring = WaveGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.Wave);
        if (gestureFlag)
        {
            Utilities.tryToTapAButton(ActionFlag.Flags.Wave, KeyCode.B);
        }
    }

    /// <summary>
    /// Returns true if the given hand's direction is straight up, ish
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool WaveGestureDetected(Hand hand)
    {
        double yStraightUp = .85;
        double handDirection = hand.Direction.y;

        return handDirection >= yStraightUp;
    }

    /// <summary>
    /// Presses left shift if the given hand is balled into a fist
    /// </summary>
    /// <param name="hand"></param>
    private void HandleFadeGesture(Hand hand)
    {
        bool gestureOccurring = FistGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.Fade);
        if (gestureFlag)
        {
            Utilities.tryToTapAButton(ActionFlag.Flags.Fade, KeyCode.LeftShift);
        }
    }

    /// <summary>
    /// Returns true if the given hand has a "strong grip", i.e., is balled into a fist
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    private bool FistGestureDetected(Hand hand)
    {
        double gripThreshold = 1;
        return hand.GrabStrength >= gripThreshold;
    }

    /// <summary>
    /// pressed q if coalescenceGesture is detected
    /// </summary>
    /// <param name="hand"></param>
    private void HandleCoalescenceGesture(Hand hand)
    {
        bool gestureOccurring = CoalescenceGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.Coalescence);
        if (gestureFlag)
        {
            Utilities.tryToTapAButton(ActionFlag.Flags.Coalescence, KeyCode.Q);
        }
    }

    /// <summary>
    /// detects whether the left hand's 4 fingers are up and the thumb is to the right
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool CoalescenceGestureDetected(Hand hand)
    {
        double coalescenceFingerDirection = .8;
        int coalescenceFingerCount = 4;
        bool thumbPass = false;

        int fingerUpCount = 0;
        foreach (Finger finger in hand.Fingers)
        {
            Vector pointDirection = finger.Direction;

            if (finger.Type != Finger.FingerType.TYPE_THUMB)
            {
                if (pointDirection.y > coalescenceFingerDirection)
                {
                    fingerUpCount++;
                }
            }
            else if (finger.Type == Finger.FingerType.TYPE_THUMB)
            {
                //System.out.println(finger.type() + " pointDirection" + pointDirection.toString());
                if (pointDirection.x > coalescenceFingerDirection)
                {
                    thumbPass = true;
                }
            }
        }

        return fingerUpCount >= coalescenceFingerCount && thumbPass;
    }

    /// <summary>
    /// Hits the left mouse button if the gesture is detected
    /// </summary>
    /// <param name="hand"></param>
    private void HandleLeftBioticGraspGesture(Hand hand)
    {
        bool gestureOccurring = BioticGraspGestureDetected(hand);
        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.LeftBioticGrasp);
        if (gestureFlag)
        {
            Utilities.tryToMouse(ActionFlag.Flags.LeftBioticGrasp, MouseButton.LeftMouse);
        }
    }

    /// <summary>
    /// detects if 5 fingers on the given hand are pointing up
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private bool BioticGraspGestureDetected(Hand hand)
    {
        int fingerUpCount = 0;

        foreach (Finger finger in hand.Fingers)
        {
            Vector pointDirection = finger.Direction;
            if (pointDirection.y > FingerPointUpNum)
            {
                fingerUpCount++;
            }
        }

        return fingerUpCount >= FingerNum;
    }
}