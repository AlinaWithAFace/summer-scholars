using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemControl : MonoBehaviour
{
    public List<ParticleSystem> ParticleSystems;

    private void Awake()
    {
        foreach (var pSystem in ParticleSystems)
        {
            pSystem.Stop();
        }
    }

    public void PlayParticleSystem()
    {
        foreach (var pSystem in ParticleSystems)
        {
            pSystem.Play();
        }
    }

    public void StopParticleSystem()
    {
        foreach (var pSystem in ParticleSystems)
        {
            pSystem.Stop();
        }
    }
}