using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshCollider))]

public class Platform : MonoBehaviour
{
    public delegate void EnemyListHandler ();
    public static event EnemyListHandler OnEmpty; 

    private List<Enemy> _enemies = new List<Enemy>();
    
    private MeshCollider _collider;    

    public int EnemiesCount => _enemies.Count;

    private void OnEnable() 
    {
        Enemy.OnDeath += RemoveEnemyFromList;
    }

    private void OnDisable() 
    {
        Enemy.OnDeath -= RemoveEnemyFromList;
    }

    private void Start() 
    {
        _collider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        Enemy enemy;

        if((enemy = other.collider.GetComponent<Enemy>()) != null) 
            AddEnemyInList(enemy);
        
    }

    private void OnCollisionExit(Collision other) 
    {
        Enemy enemy;

        if((enemy = other.collider.GetComponent<Enemy>()) != null)
        {
            RemoveEnemyFromList(enemy);
            enemy.Die();
        }
    }

    private void AddEnemyInList(Enemy enemy) 
    {
        _enemies.Add(enemy);
    }

    private void RemoveEnemyFromList(Enemy enemy) 
    {
    
        if(_enemies.Contains(enemy) == false) return;

        _enemies.Remove(enemy);

        if(_enemies.Count <= 0) 
            OnEmpty.Invoke();
    }
}
