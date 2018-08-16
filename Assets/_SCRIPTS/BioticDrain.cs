using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEngine;

public class BioticDrain : MonoBehaviour
{
    public HandModelBase HandModelBase;
    public ParticleSystem DrainParticleSystem;


    public float PullDistance = 200;
    public Transform MagnetPoint;
    public int TimeUntilPull = 0;

    private bool waitCalled = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Time until pull equals " + TimeUntilPull);
    }

    // Update is called once per frame
    void Update()
    {
        if (MagnetPoint != null)
        {
            DrainParticleSystem.Play();
        }
        else
        {
            DrainParticleSystem.Stop();
        }


        if ((TimeUntilPull > 0) & (waitCalled == false))
        {
            Debug.Log("Coroutine called");
            StartCoroutine(ParticleWait());
        }
        else if (TimeUntilPull == 0)
            ParticlePull();
    }


    IEnumerator ParticleWait()
    {
        waitCalled = true;
        yield return new WaitForSeconds(TimeUntilPull);
        TimeUntilPull = 0;
        Debug.Log("TimeUntilPull set to 0");
    }

    void ParticlePull()
    {
        float sqrPullDistance = PullDistance * PullDistance;

        ParticleSystem.Particle[] x = new ParticleSystem.Particle[DrainParticleSystem.particleCount + 1];
        int y = DrainParticleSystem.GetParticles(x);

        for (int i = 0; i < y; i++)
        {
            Vector3 offset = MagnetPoint.localPosition - x[i].position;
            //creates Vector3 variable based on the position of the target MagnetPoint (set by user) and the current particle position
            float sqrLen = offset.sqrMagnitude;
            //creats float type integer based on the square magnitude of the offset variable set above (faster than .Magnitude)

            if (sqrLen <= sqrPullDistance)
            {
                x[i].position = Vector3.Lerp(x[i].position, MagnetPoint.localPosition,
                    Mathf.SmoothStep(0, 2, (Time.deltaTime / 0.1F)));
                /*Lerping moves an object between two vectors (syntax is FromVector, ToVector, Fraction) by a given fraction. In our example 
                we take the position of particle i, of particle system x, and the local position of the MagnetPoint transform, and move the 
                particles in from x[i] towards MagnetPoint over time. Lower the Time.deltaTime / # value to increase how fast the particle attracts*/
                if ((x[i].position - MagnetPoint.localPosition).magnitude <= 30)
                {
                    x[i].remainingLifetime = 0;
                }
            }
        }

        DrainParticleSystem.SetParticles(x, y);
        return;
    }
}


