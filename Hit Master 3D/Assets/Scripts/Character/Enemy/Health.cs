using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    private float _healthPoints;

    public float HealthPoints => _healthPoints;

    public virtual void TakeDamage(float damage) 
    {
        if(damage < 0)
            throw new ArgumentException($"Damage : {damage} is not correct value, damage must be greater than zero");
    }
}
