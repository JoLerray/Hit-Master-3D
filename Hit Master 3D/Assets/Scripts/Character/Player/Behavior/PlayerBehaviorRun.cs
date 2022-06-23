using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerBehaviorRun : PlayerBehavior 
{
    public PlayerBehaviorRun(Player player) : base(player) {}

    public override void Enter()
    {
        try
        {
            Player.Animator.SetBool("isRun",true);
        }
        catch 
        {
            Player.SetEmptyBehavor();
        }
    }

    public override void Update() 
    {
        Player.Movable.Move();
    }

    public override void Exit() {}

 
}
