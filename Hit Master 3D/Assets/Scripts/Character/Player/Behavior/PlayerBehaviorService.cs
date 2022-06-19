using System.Collections.Generic;
using System;

public sealed class PlayerBehaviorService
{
    private Dictionary<Type, IBehavior> _behaviorsMap;
    private IBehavior _behaviorCurrent;

    private Player _player;

    public PlayerBehaviorService(Player player) 
    {
        if(player == null) throw new ArgumentNullException("Player not installed");

        _player = player;

        InitBehaviours();
        SetBehaviorByDefault();
    }

    private void InitBehaviours() 
    {
        _behaviorsMap = new Dictionary<Type, IBehavior>();
        
        _behaviorsMap[typeof(PlayerBehaviorIdle)] = new PlayerBehaviorIdle(_player);
        _behaviorsMap[typeof(PlayerBehaviorRun)] = new PlayerBehaviorRun(_player);
    }

    public void UpdateBehavior() 
    {
        if(_behaviorCurrent != null) _behaviorCurrent.Update();
    }

    private void SetBehavior(IBehavior newBehavior) 
    {
        if(_behaviorCurrent != null)
            _behaviorCurrent.Exit();
        
        _behaviorCurrent = newBehavior;
        _behaviorCurrent.Enter();
    }

    private IBehavior GetBehavior<T>() where T: IBehavior {
        var type = typeof(T);
        return _behaviorsMap[type];
    }

    private void SetBehaviorByDefault() {
        var behaviorByDefaul = this.GetBehavior<PlayerBehaviorRun>();
        this.SetBehavior(behaviorByDefaul);
    }

    public void SetBehaviorIdle() {
        var behavior = GetBehavior<PlayerBehaviorIdle>();
        SetBehavior(behavior);
    }

    public void SetBehaviorRun() {
        var behavior = GetBehavior<PlayerBehaviorRun>();
        SetBehavior(behavior);
    }
}
