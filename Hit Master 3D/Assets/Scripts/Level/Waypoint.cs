using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Waypoint : MonoBehaviour
{

    public delegate void PlayerWaypointTrigerHandler (Waypoint waypoint);
    public static event PlayerWaypointTrigerHandler OnTriger; 
    
    [SerializeField] private float _radius;
    
    [SerializeField] private Platform _platform;

    [SerializeField] private Waypoint _nextWaypoint;
    
    private SphereCollider _collider;
    
    public Platform Platform => _platform;

    public Waypoint NextWaypoint => _nextWaypoint;

    private bool _flagTrigger = false;

    public bool FlagTrigger => _flagTrigger;

    private void Start() {
        
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _radius;   
        if(_collider.isTrigger != true) throw new ArgumentException("Waypoint collider is not trigger");
    }

    
    private void OnTriggerEnter(Collider other) {

        if((other.GetComponent<Player>()) != null ) 
        {
           
            OnTriger.Invoke(this);
            _flagTrigger = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position,_radius);
    }
}
