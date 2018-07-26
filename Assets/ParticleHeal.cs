using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHeal : MonoBehaviour
{
    private List<ParticleCollisionEvent> _collisionEvents;
    private ParticleSystem _particleSystem;

    // Use this for initialization
    void Start()
    {
        _collisionEvents = new List<ParticleCollisionEvent>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(this.gameObject.name + " hit by " + other.gameObject.name);

        if (other.gameObject.CompareTag("Ally"))
        {
            StartCoroutine(other.gameObject.GetComponent<HealthAndDying>().GetHealed());
        }
    }
}