using JetBrains.Annotations;
using Leap;
using Leap.Unity;
using UnityEngine;

[ExecuteInEditMode]
public class FollowPalmNormal : MonoBehaviour
{
    public HandModelBase Target;
    [Range(0, 1)] public float PalmNormalPercent;

    void Update()
    {
        Vector3 palmPosition = Target.GetLeapHand().PalmPosition.ToVector3();
        Vector3 palmNormal = Target.GetLeapHand().PalmNormal.ToVector3();
        Debug.DrawRay(palmPosition, palmNormal);
        this.transform.position = palmPosition + (palmNormal * PalmNormalPercent);
        this.transform.LookAt(palmPosition + palmNormal);
    }
}