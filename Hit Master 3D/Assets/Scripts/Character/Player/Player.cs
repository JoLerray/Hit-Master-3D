using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Waypoint[] _weypoints;

    private PlayerBehaviorService _behaviorService;

    private void OnEnable() {
        LevelServices.OnStart += InitBehaviorService;
    }

    private void OnDisable() {
       LevelServices.OnStart -= InitBehaviorService;
    }

    private void InitBehaviorService() {
        _behaviorService = new PlayerBehaviorService(this);
    }
    
    private void Update() {
        if(_behaviorService != null)
            _behaviorService.UpdateBehavior();
    }
}
