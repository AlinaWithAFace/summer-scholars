using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject gameObject;
    public int delay = 3;
    public int lifetime = 10;
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float thrust = .2f;

    private void Start()
    {
        InvokeRepeating("SpawnTheThings", 3, delay);
    }

    void SpawnTheThings()
    {
        var newThing = Instantiate(gameObject);
        PushTheThing(newThing);
        StartCoroutine(ScheduleMurder(newThing, lifetime));
    }

    private void Update()
    {
        Debug.DrawLine(StartPos, EndPos);
    }

    IEnumerator ScheduleMurder(GameObject objectToKill, int timeToWaitToKill)
    {
        yield return new WaitForSeconds(timeToWaitToKill);
        Destroy(objectToKill);
    }

    void PushTheThing(GameObject objectToPush)
    {
        var heading = EndPos - StartPos;
        objectToPush.GetComponent<Rigidbody>().AddForce(heading * thrust);
    }
}