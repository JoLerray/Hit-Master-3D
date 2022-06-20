using UnityEngine;

public class EnemyHealth : Health
{
    public delegate void EnemyTakeDamgeHandler (Transform target, float damage, float healthPointsMax,float oldHeatPoints,float newHeatPoints);
    public static event EnemyTakeDamgeHandler OnTakeDamage; 

    public override void TakeDamage(float damage)
    {
        var oldHeatPoints = HealthPoints;
        base.TakeDamage(damage);

        OnTakeDamage.Invoke(this.transform, damage, HealthPointsMax, oldHeatPoints, HealthPoints);

        if(HealthPoints <= 0)
        {
            this.GetComponent<IDeath>().Die();   
        }
        
    }

}
