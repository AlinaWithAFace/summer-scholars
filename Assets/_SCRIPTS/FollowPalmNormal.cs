﻿using System;
using JetBrains.Annotations;
using Leap;
using Leap.Unity;
using LeapInternal;
using UnityEngine;

[ExecuteInEditMode]
public class FollowPalmNormal : MonoBehaviour
{
    public HandModelBase Target;
    [Range(0, 1)] public float PalmNormalPercent;
    public bool showGizmos;

    private Vector3 _palmPosition;
    private Vector3 _palmNormal;
    public Vector3 positionCorrection;

    private void Start()
    {
        _palmPosition = Vector3.forward;
        _palmNormal = Vector3.forward;
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Target.isActiveAndEnabled)
            {
                _palmPosition = Target.GetLeapHand().PalmPosition.ToVector3();
                _palmNormal = Target.GetLeapHand().PalmNormal.ToVector3();

                if (!(_palmPosition != null | _palmNormal != null)) return;
                if (showGizmos)
                {
                    Debug.DrawRay(_palmPosition, _palmNormal);
                }

                transform.position = _palmPosition + (_palmNormal * PalmNormalPercent);
                transform.LookAt(_palmPosition + _palmNormal);

                Vector3 correctedVector3 = transform.position + positionCorrection;

                transform.SetPositionAndRotation(correctedVector3, transform.rotation);
            }
        }
        else
        {
            _palmPosition = Vector3.forward;
            _palmNormal = Vector3.forward;
        }
    }
}