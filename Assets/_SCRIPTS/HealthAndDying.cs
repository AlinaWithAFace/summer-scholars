using System;
using System.Collections;
using UnityEngine;

public class HealthAndDying : MonoBehaviour
{
    public float MaxHealth = 3;
    internal float CurrentHealth = 3;
    public Renderer Renderer;
    public Color LiveColor = Color.green;
    public Color DeadColor = Color.red;
    public float HealthPercentage;
    private bool _hitable;

    // Use this for initialization
    void Start()
    {
        Renderer = GetComponent<Renderer>();
        _hitable = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthPercentage = CurrentHealth / MaxHealth;
        Renderer.material.color = Color.Lerp(DeadColor, LiveColor, HealthPercentage);

        if (HealthPercentage <= 0)
        {
            Debug.Log(this.gameObject.name + " dead");
            Destroy(this.gameObject);
        }
    }

    public IEnumerator GetHit()
    {
        Debug.Log(this.name + " hit, hp: " + HealthPercentage);
        if (_hitable)
        {
            _hitable = false;
            CurrentHealth--;
            yield return new WaitForSeconds(.4f);
            _hitable = true;
        }
    }
}