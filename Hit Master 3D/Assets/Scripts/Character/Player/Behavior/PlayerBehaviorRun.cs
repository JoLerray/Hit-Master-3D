using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerBehaviorRun : PlayerBehavior 
{
    public PlayerBehaviorRun(Player player) : base(player) {}

    public override void Enter() {}

    public override void Update() {
        Debug.Log("Run");
        Run();}

    public override void Exit() {}

    private void Run() 
    {
        foreach(var waypoint in Player.Waypoints) 
        {
            if(waypoint.FlagTrigger != true)
            {
                Player.NavMeshAgent.SetDestination(waypoint.transform.position);
                return;
            }
        }
    }
}
