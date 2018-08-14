using System;
using System.Collections;
using UnityEngine;

public class HealthAndDying : MonoBehaviour
{
    public float MaxHealth = 3;
    public float CurrentHealth = 3;
    public Renderer Renderer;
    public Color LiveColor = Color.green;
    public Color DeadColor = Color.red;
    private float _healthPercentage;
    private bool _hitable;
    private bool _healable;

    // Use this for initialization
    void Start()
    {
        Renderer = GetComponent<Renderer>();
        _hitable = true;
        _healable = true;
    }

    // Update is called once per frame
    void Update()
    {
        ColorByHealth();
    }

    public IEnumerator GetHit()
    {
        if (_hitable)
        {
            _hitable = false;
            CurrentHealth--;
            Debug.Log(this.name + " hit, hp: " + CurrentHealth + " / " + MaxHealth);
            yield return new WaitForSeconds(.4f);
            _hitable = true;

            if (_healthPercentage <= 0)
            {
                Debug.Log(this.gameObject.name + " dead");
                Destroy(this.gameObject);
            }
        }
    }

    public IEnumerator GetHealed()
    {
        if (_healable)
        {
            _healable = false;
            CurrentHealth++;
            Debug.Log(this.name + " healed, hp: " + CurrentHealth + " / " + MaxHealth);
            yield return new WaitForSeconds(.4f);
            _healable = true;
        }
    }

    void ColorByHealth()
    {
        Debug.Log(_healthPercentage);
        _healthPercentage = CurrentHealth / MaxHealth;
        Renderer.material.color = Color.Lerp(DeadColor, LiveColor, _healthPercentage);
    }
}