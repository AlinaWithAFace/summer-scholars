//using System.Collections;
//using System.Collections.Generic;
//using Leap;
//using Leap.Unity;
//using UnityEngine;
//
//public class MovementListener : MonoBehaviour
//{
//    // Use this for initialization
//    void Start()
//    {
//    }
//
//
//    private double zMid = .5;
//    private double zPadding = .20;
//
//    private double yMid = .5;
//    private double yPadding = .20;
//
//    private double xMid = .25;
//    private double xPadding = .20;
//
//
//    // Update is called once per frame
//    void Update()
//    {
//        Frame frame = controller.frame();
//        interactionBox interactionBox = frame.interactionBox();
//
//        Hand leftHand = Hands.Left;
//
//        HandleForward(leftHand, interactionBox);
//        HandleLeft(leftHand, interactionBox);
//        HandleBackward(leftHand, interactionBox);
//        HandleRight(leftHand, interactionBox);
//        HandleJump(leftHand, interactionBox);
//        HandleCrouch(leftHand, interactionBox);
//    }
//
//    private void HandleCrouch(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = CrouchMovementHoverDetected(hand, interactionBox);
//        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.Crouch);
//        if (gestureFlag)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.Crouch, KeyCode.LeftControl);
//        }
//    }
//
//    private bool CrouchMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        throw new System.NotImplementedException();
//    }
//
//    /// <summary>
//    /// Hit the space key
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    private void HandleJump(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = JumpMovementHoverDetected(hand, interactionBox);
//        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.Jump);
//        if (gestureFlag)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.Jump, KeyCode.Space);
//        }
//    }
//
//    /// <summary>
//    /// Check if the given hand is hovering relatively high in order to trigger a jump
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    /// <returns></returns>
//    private bool JumpMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        double yMax = yMid + yPadding;
//        Vector palmPosition = interactionBox.normalizePoint(hand.StabilizedPalmPosition);
//        return palmPosition.y >= yMax;
//    }
//
//    /// <summary>
//    /// pushes the d key if rightMovementHoverDetected is true
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    private void HandleRight(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = RightMovementHoverDetected(hand, interactionBox);
//        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.MoveRight);
//        if (gestureFlag)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.MoveRight, KeyCode.D);
//        }
//    }
//
//    private bool RightMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        throw new System.NotImplementedException();
//    }
//
//    /// <summary>
//    /// pushes the s button if backwardMovementHoverDetected is true
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    private void HandleBackward(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = BackwardMovementHoverDetected(hand, interactionBox);
//        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.MoveBackward);
//        if (gestureFlag)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.MoveBackward, KeyCode.S);
//        }
//    }
//
//    private bool BackwardMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        throw new System.NotImplementedException();
//    }
//
//    /// <summary>
//    /// pushes the a key if leftMovementHoverDetected is true
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    private void HandleLeft(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = LeftMovementHoverDetected(hand, interactionBox);
//        bool gestureFlag = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.MoveLeft);
//        if (gestureFlag)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.MoveLeft, KeyCode.A);
//        }
//    }
//
//    private bool LeftMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        throw new System.NotImplementedException();
//    }
//
//    /// <summary>
//    /// pushes the w key if forwardMovementHoverDetected is true
//    /// </summary>
//    /// <param name="hand"></param>
//    /// <param name="interactionBox"></param>
//    private void HandleForward(Hand hand, interactionBox interactionBox)
//    {
//        bool gestureOccurring = ForwardMovementHoverDetected(hand, interactionBox);
//        bool gestureChange = Utilities.detectGestureChange(gestureOccurring, ActionFlag.Flags.MoveForward);
//        if (gestureChange)
//        {
//            Utilities.tryToPressAButton(ActionFlag.Flags.MoveForward, KeyCode.W);
//        }
//    }
//
//    private bool ForwardMovementHoverDetected(Hand hand, interactionBox interactionBox)
//    {
//        throw new System.NotImplementedException();
//    }
//}