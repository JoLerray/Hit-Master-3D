using UnityEngine;

public class EnemyHealth : Health
{
    public delegate void EnemyTakeDamgeHandler (Transform target, float damage, float oldHeatPoints,float newHeatPoints);
    public static event EnemyTakeDamgeHandler OnTakeDamage; 

    public override void TakeDamage(float damage)
    {
        var oldHeatPoints = HealthPoints;
        base.TakeDamage(damage);

        OnTakeDamage.Invoke(this.transform, damage, oldHeatPoints, HealthPoints);
    }
}
