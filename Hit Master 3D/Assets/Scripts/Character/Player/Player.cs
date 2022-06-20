using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;

    [SerializeField] private GameObject _movement;

    [SerializeField] private GameObject _shooting;

    private PlayerBehaviorService _behaviorService;

    private Animator _animator;

    private IMovable _movable;

    private IShootable _shootable;

    public Waypoint[] Waypoints => _waypoints;
    
    public IMovable Movable => _movable;

    public IShootable Shootable => _shootable;

    public Animator Animator => _animator;

    private void OnEnable() 
    {
        LevelServices.OnStart += InitBehaviorService;
        Waypoint.OnTriger += SetBehavoir;
    } 

    private void OnDisable() 
    {
        LevelServices.OnStart -= InitBehaviorService;
        Waypoint.OnTriger -= SetBehavoir;
    }
    
    private void Start() 
    {
        if((_movable =_movement.GetComponent<IMovable>()) == null) 
            throw new ArgumentNullException("Movement don't have IMovable interface");

        if((_shootable = _shooting.GetComponent<IShootable>()) == null) 
            throw new ArgumentNullException("Shooting don't have IShootable interface");

        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(_behaviorService != null)
            _behaviorService.UpdateBehavior();
    }

    private void InitBehaviorService() 
    {
        _behaviorService = null;
        _behaviorService = new PlayerBehaviorService(this);
        Platform.OnEmpty += _behaviorService.SetBehaviorRun;
    }
    
    private void SetBehavoir(Waypoint waypoint) 
    {
        if (waypoint.NextWaypoint != null && waypoint.NextWaypoint.Platform.EnemiesCount <= 0) 
            _behaviorService.SetBehaviorRun();
            
        else 
            _behaviorService.SetBehaviorIdle();
    }

    private void OnDestroy() 
    {
        Platform.OnEmpty -= _behaviorService.SetBehaviorRun;
        _behaviorService.SetBehaviorRun();
        _behaviorService = null;
    }
}
