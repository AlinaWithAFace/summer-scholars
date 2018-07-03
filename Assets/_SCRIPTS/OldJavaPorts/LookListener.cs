////using System.Windows;
//using Leap;
//using Leap.Unity;
//using UnityEditor;
//using UnityEngine;
//using Vector = Leap.Vector;
//
//public class LookListener : MonoBehaviour
//{
//    // Use this for initialization
//    void Start()
//    {
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        //Frame frame = controller.frame();
//        //InteractionBox interactionBox = frame.interactionBox();
//
//        Hand rightHand = Hands.Right;
//        //HandleHand(rightHand, interactionBox);
//    }
//
//    // This range is the interaction box's beginning and end.
//    // In other words, normalizing the hand's point direction will give you a value between 0 and 1
//    // This is that range
//    private static double boxRangeStart = 0;
//    private static double boxRangeEnd = 1;
//
//    // This is the right half of the interaction box.
//    // We want to keep the right hand in the right half of the box to give the left it's own space,
//    // but we still want full mouse movement, so we map this half to the whole box
//    private static double xRightRangeStart = .5;
//    private static double xRightRangeEnd = 1;
//
//    private static double yRightRangeStart = 0;
//    private static double yRightRangeEnd = 1;
//
//    // The screen size, we only map the hand's direction to a portion of the screen, because you really only need some of it for a FPS
//
//    private static readonly int XScreenMid = Screen.width / 2;
//    private static readonly int XBuffer = Screen.width / 12;
//    private static readonly int XScreenMin = XScreenMid - XBuffer;
//    private static readonly int XScreenMax = XScreenMid + XBuffer;
//    private static readonly int XScreenDiff = XScreenMax - XScreenMin;
//
//    private static readonly int YScreenMid = Screen.height / 2;
//    private static readonly int YBuffer = Screen.height / 12;
//    private static readonly int YScreenMin = YScreenMid - YBuffer;
//    private static readonly int YScreenMax = YScreenMid + YBuffer;
//    private static readonly int YScreenDiff = YScreenMax - YScreenMin;
//
//    // The ratio between the ranges, i.e. the thing used for mapping from on range to the other
//    private static readonly double RangeRatio = (boxRangeEnd - boxRangeStart) / (xRightRangeEnd - xRightRangeStart);
//
////    private void HandleHand(Hand hand, InteractionBox interactionBox)
////    {
////        //TODO: this is still hyper-sensitive, but I'm not sure how to make it better
////        Vector rawHandPos = hand.StabilizedPalmPosition;
////        Vector boxHandPos = interactionBox.normalizePoint(rawHandPos);
////        double newX = Input.mousePosition.x;
////        double newY = Input.mousePosition.y;
////
////        bool xInRange = xRightRangeStart < boxHandPos.x & boxHandPos.x < xRightRangeEnd;
////        bool yInRange = yRightRangeStart < boxHandPos.y & boxHandPos.y < yRightRangeEnd;
////
////        // Is the hand in the overall range?
////        if (xInRange)
////        {
////            // Fancy Mathematics to map the right hand's range to the full range, thanks stack overflow
////            double newXPos = (boxHandPos.x - xRightRangeStart) * RangeRatio + boxRangeStart;
////            newX = (int) (newXPos * XScreenDiff) + XScreenMin;
////        }
////
////        if (yInRange)
////        {
////            double newYPos = boxHandPos.y;
////            newY = (int) (Screen.height - (YScreenDiff * newYPos + YScreenMin));
////        }
////
////        //System.out.printf("%d < %f > %d | %d < %f > %d\n", xScreenMin, newX, xScreenMax, yScreenMin, newY, yScreenMax);
////        //robot.mouseMove((int) newX, (int) newY);
////        System.Windows.Forms.Cursor.Position = new Point(newX, newY);
////    }
//}