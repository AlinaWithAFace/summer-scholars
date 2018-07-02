using System;
using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int TimeLeft = 60;
    public Text CountdownText;
    private bool _recording;
    public Hand Hand;


    // Use this for initialization
    void Start()
    {
        CountdownText = CountdownText == null ? gameObject.GetComponent<Text>() : CountdownText;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownText.text = ("" + TimeLeft);
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
    }
    
    void Reset()
    {
        TimeLeft = 60;
    }

    void StartRecording()
    {
        _recording = true;
    }

    void StopRecording()
    {
        _recording = false;
    }

    void SaveHand()
    {
        if (_recording)
        {
            Console.WriteLine(Hand.ToString());
        }
    }
}