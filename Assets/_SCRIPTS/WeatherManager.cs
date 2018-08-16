using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using _SCRIPTS;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public float cloudValue { get; private set; }

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        _network = service;
        StartCoroutine(_network.GetWeatherXml(OnXmlDataLoaded));
        status = ManagerStatus.Initializing;
    }

    public void OnXmlDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;

        Debug.Log("Value: " + value);

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
        status = ManagerStatus.Started;
    }
}