using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject gameObject;
    public int delay = 3;
    public int lifetime = 10;

    private void Start()
    {
        InvokeRepeating("SpawnTheThings", 3, delay);
    }

    void SpawnTheThings()
    {
        Instantiate(gameObject);
    }
}