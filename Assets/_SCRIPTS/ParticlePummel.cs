using System.Collections.Generic;
using UnityEngine;

public class ParticlePummel : MonoBehaviour
{
    private List<ParticleCollisionEvent> _collisionEvents;
    private ParticleSystem _particleSystem;

    void Start()
    {
        _collisionEvents = new List<ParticleCollisionEvent>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(this.gameObject.name + " hit by " + other.gameObject.name);
        ParticlePhysicsExtensions.GetCollisionEvents(_particleSystem, other, _collisionEvents);


        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(other.gameObject.GetComponent<HealthAndDying>().GetHit());
        }
    }
}