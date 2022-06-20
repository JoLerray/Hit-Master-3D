using UnityEngine;

public class Enemy : MonoBehaviour, IDeath
{
    public delegate void EnemyDeathHandler (Enemy enemy);
    public static event EnemyDeathHandler OnDeath; 

    public void Die() 
    {
        OnDeath.Invoke(this);
        Destroy(gameObject);
    }
}
