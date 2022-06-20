using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float _healthPointsMax;

    private float _healthPoints;

    public float HealthPoints => _healthPoints;

    public float HealthPointsMax => _healthPointsMax;

    private void Start() 
    {
        _healthPoints = _healthPointsMax;    
    }
     
    public virtual void TakeDamage(float damage) 
    {
        if(damage < 0)
            throw new ArgumentException($"Damage : {damage} is not correct value, damage must be greater than zero");
        
        _healthPoints -= damage;
    }
}
