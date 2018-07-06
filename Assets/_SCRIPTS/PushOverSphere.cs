using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PushOverSphere : MonoBehaviour
{
    public Transform ResetPosition;
    public Rigidbody Rigidbody;
    public HandModelBase HandModelBase;

    // Use this for initialization
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = ResetPosition.position;
        }

        Rigidbody.AddForce(HandModelBase.GetLeapHand().PalmPosition.ToVector3());
    }

    // Update is called once per frame
    void Update()
    {
        if (HandModelBase.isActiveAndEnabled)
        {
            Rigidbody.AddForceAtPosition(HandModelBase.GetLeapHand().StabilizedPalmPosition.ToVector3(), transform.position);
        }
    }
}