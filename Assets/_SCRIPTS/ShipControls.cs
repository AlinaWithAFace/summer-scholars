using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[]
public class ShipControls : MonoBehaviour
{
    private int selected = 0;

    public string[] ButtonSelect = new string[]
    {
        "FORWARD", "BACKWARD", "LEFT", "RIGHT"
    };

    
    public float thrust;
    public Transform ThingToForceForward;
    public bool debugTrue = true;

    // Use this for initialization
    void Start()
    {
        selected = EditorGUILayout.Popup("Label", selected, ButtonSelect);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || debugTrue)
        {
           // ThingToForceForward.forward;
        }
    }
    
}