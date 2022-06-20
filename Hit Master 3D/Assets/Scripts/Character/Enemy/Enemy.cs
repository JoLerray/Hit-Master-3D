using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private RagdollSwitcher _ragdollSwitcher;

    public delegate void EnemyDeathHandler (Enemy enemy);
    public static event EnemyDeathHandler OnDeath; 

    public void Die() 
    {
        _ragdollSwitcher.SwitchRagdoll();
        OnDeath.Invoke(this);
        //Destroy(gameObject);
    }
}
