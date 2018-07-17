using System;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    public List<HandModelBase> Hands;
    private Color _originalColor = Color.black;
    public Color NewColor = Color.black;

    private void Awake()
    {
        if (Hands[0] != null)
        {
            _originalColor = Hands[0].GetComponentInChildren<Renderer>().material.color;
        }

        Debug.Log("Original Color " + _originalColor);
    }

    public void TurnColor()
    {
        foreach (var handModelBase in Hands)
        {
            handModelBase.GetComponentInChildren<Renderer>().material.color = NewColor;
        }
    }

    public void UnColor()
    {
        foreach (var handModelBase in Hands)
        {
            handModelBase.GetComponentInChildren<Renderer>().material.color = _originalColor;
        }
    }
}