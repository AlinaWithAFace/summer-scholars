using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class PianoManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by " + other.gameObject.name);
        PlayAudio();
    }

    public void PlayAudio()
    {
        Debug.Log("Playing Audio!");
        _audioSource.Play();
    }
}