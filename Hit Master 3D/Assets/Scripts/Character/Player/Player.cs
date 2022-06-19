using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    
    [SerializeField] private Waypoint[] _waypoints;

    private PlayerBehaviorService _behaviorService;

    private NavMeshAgent _navMeshAgent;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    public Waypoint[] Waypoints => _waypoints;

    private void OnEnable() {
        LevelServices.OnStart += InitBehaviorService;
        Waypoint.OnTriger += SetBehavoir;
        
    } 

    private void OnDisable() {
        LevelServices.OnStart -= InitBehaviorService;
        Waypoint.OnTriger -= SetBehavoir;
       
    }

    private void Start() {
        
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if(_behaviorService != null)
            _behaviorService.UpdateBehavior();
    }

    private void InitBehaviorService() {
        _behaviorService = new PlayerBehaviorService(this);
        Platform.OnEmpty += _behaviorService.SetBehaviorRun;
    }
    
    private void SetBehavoir(Waypoint waypoint) 
    {
        if (waypoint.NextWaypoint != null && waypoint.NextWaypoint.Platform.EnemiesCount <= 0) 
            _behaviorService.SetBehaviorRun();
            
        else _behaviorService.SetBehaviorIdle();
    }
    
    private void OnDestroy() {
        Platform.OnEmpty -= _behaviorService.SetBehaviorRun;
    }
    
}
