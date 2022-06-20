using System.Collections;

using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDeathHandler (Enemy enemy);
    public static event EnemyDeathHandler OnDeath; 

    public void Die() 
    {
        OnDeath.Invoke(this);
        Destroy(gameObject);
    }
}
