using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _SCRIPTS;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material _sky;
    [SerializeField] private Light _sun;

    private float _fullIntensity;
    private float _cloudValue = 0f;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    // Use this for initialization
    void Start()
    {
        _fullIntensity = _sun.intensity;
    }

    private void OnWeatherUpdated()
    {
        SetOvercast(Managers.Weather.cloudValue);
        Debug.Log("Set Clouds to " + Managers.Weather.cloudValue);
    }

    private void SetOvercast(float value)
    {
        _sky.SetFloat("_Blend", value);
        _sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}