using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]


public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _damage = 1;
    
    public Rigidbody Rigidbody => _rigidbody;

    private void OnEnable() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        IHealth healthTarget;
        
        if((healthTarget = other.collider.transform.GetComponent<IHealth>()) != null)
            healthTarget.TakeDamage(_damage);
            
        gameObject.SetActive(false);
    }
}
