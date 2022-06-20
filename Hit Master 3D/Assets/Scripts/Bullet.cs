using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    public Rigidbody Rigidbody => _rigidbody;

    private void OnEnable() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        Enemy enemy;

        if((enemy = other.collider.GetComponent<Enemy>()) != null)
            enemy.Die();

        gameObject.SetActive(false);
    }
}
