using System;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    public List<HandModelBase> hands;
    //public HandModelBase HandModelBase;

    private Color _originalColor = Color.black;
    public Color NewColor = Color.black;

    private void Awake()
    {
        _originalColor = hands[0].GetComponentInChildren<Renderer>().material.color;
        Debug.Log("Original Color " + _originalColor);
    }

    public void TurnColor()
    {
        foreach (var handModelBase in hands)
        {
            handModelBase.GetComponentInChildren<Renderer>().material.color = NewColor;
        }

        //myColor = new Color(Random.value, Random.value, Random.value);
        //HandModelBase.GetComponentInChildren<Renderer>().material.color = NewColor;
    }

    public void UnColor()
    {
        //HandModelBase.GetComponentInChildren<Renderer>().material.color = _originalColor;
        foreach (var handModelBase in hands)
        {
            handModelBase.GetComponentInChildren<Renderer>().material.color = _originalColor;
        }
    }
}