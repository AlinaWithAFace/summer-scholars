using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ForceParentToTarget : MonoBehaviour
{
    public Transform ResetPosition;
    public String TagToTarget = "Player";
    public int TimeToKill = 10;
    public float thrust = .2f;
    public Vector3 StartPos;
    public Vector3 EndPos;

    // Use this for initialization
    void Start()
    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            transform.position = ResetPosition.position;
//        }
//
//
//        target = FindClosestWithTag(TagToTarget).transform;

        StartPos = transform.position;
        StartCoroutine(ScheduleMurder(TimeToKill));
    }

    // Update is called once per frame
    void Update()
    {
        //var start = transform.position;
        //var end = target.transform.position;
        Debug.DrawLine(StartPos, EndPos);

        // Gets a vector that points from the player's position to the target's.
        var heading = EndPos - StartPos;

        if (this.isActiveAndEnabled)
        {
            GetComponent<Rigidbody>().AddForce(heading * thrust);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, maxSpeed);
        }
    }

    public GameObject FindClosestWithTag(string tagToFind)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tagToFind);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (!(curDistance < distance)) continue;
            closest = go;
            distance = curDistance;
        }

        return closest;
    }


    IEnumerator ScheduleMurder(int delay)
    {
        while (this.isActiveAndEnabled)
        {
            yield return new WaitForSeconds(delay);
            Destroy(this.gameObject);
        }
    }
}