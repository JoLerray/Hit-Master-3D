using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDeathHandler (Enemy enemy);
    public static event EnemyDeathHandler OnDeath; 

    void Start()
    {
        StartCoroutine(Death());
    }

    public void Die() {

        OnDeath.Invoke(this);
        Destroy(gameObject);
    }

    IEnumerator Death() {
        yield return new WaitForSeconds(15f);
        Die();    
    }
}
