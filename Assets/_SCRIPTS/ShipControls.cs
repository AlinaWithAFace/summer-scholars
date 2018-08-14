using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Valve.VR.InteractionSystem;
using _SCRIPTS;

[System.Serializable]
public enum ButtonSelect
{
    Forward,
    Backward,
    Left,
    Right,
    ThrustUp,
    ThrustDown
};


public class ShipControls : MonoBehaviour
{
    public ButtonSelect myButtonSelect = ButtonSelect.Forward;
    public Transform ThingToForceForward = ShipManager.ShipTransform;
    public bool debugTrue = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player") || debugTrue)
        {
            switch (myButtonSelect)
            {
                case ButtonSelect.Forward:
                    ThingToForceForward.Translate(Vector3.forward * Time.deltaTime * ShipManager.thrust);
                    break;
                case ButtonSelect.Backward:
                    ThingToForceForward.Translate(Vector3.back * Time.deltaTime * ShipManager.thrust);
                    break;
                case ButtonSelect.Left:
                    ThingToForceForward.Translate(Vector3.left * Time.deltaTime * ShipManager.thrust);
                    break;
                case ButtonSelect.Right:
                    ThingToForceForward.Translate(Vector3.right * Time.deltaTime * ShipManager.thrust);
                    break;
                case ButtonSelect.ThrustUp:
                    ShipManager.ChangeThrust(1);
                    break;
                case ButtonSelect.ThrustDown:
                    ShipManager.ChangeThrust(-1);
                    break;
                default:
                    Debug.Log("Something Broke?");
                    break;
            }
        }
    }
}