using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualAxisExample : MonoBehaviour
{
    public float Range;
    //public GUIText TextOutput;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float xPos = h * Range;
        float yPos = v * Range;

        transform.position = new Vector3(xPos, yPos, 0);
        String text = "Horizontal Value Returned: " +
                      h.ToString("F2") +
                      "\nVertical Value Returned: " +
                      v.ToString("F2");
        
//        TextOutput.text = "Horizontal Value Returned: " +
//                          h.ToString("F2") +
//                          "\nVertical Value Returned: " +
//                          v.ToString("F2");
        Debug.Log(text);
    }
}