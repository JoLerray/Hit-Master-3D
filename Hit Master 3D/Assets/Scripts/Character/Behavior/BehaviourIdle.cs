using UnityEngine;

public abstract class BehaviorIdle : IBehavior
{
    public virtual void Enter() {Debug.Log("Enter to Idle ");}

    public virtual void Update() {Debug.Log("In Idle");}

    public virtual void Exit() {Debug.Log("Exit in idle");}
}
