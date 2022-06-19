using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerBehaviorIdle : PlayerBehavior {
    
    public PlayerBehaviorIdle(Player player) : base(player) {}

    public override void Enter() {Debug.Log("Enter in run");}

    public override void Update() {Debug.Log("In run");}

    public override void Exit() {Debug.Log("Exit in run"); }
}
