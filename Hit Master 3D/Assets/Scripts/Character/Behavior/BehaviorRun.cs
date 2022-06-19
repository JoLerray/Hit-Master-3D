using UnityEngine;

public abstract class BehaviorRun : IBehavior
{
    public virtual void Enter() {Debug.Log("Enter in run");}

    public virtual void Update() {Debug.Log("In run");}

    public virtual void Exit() {Debug.Log("Exit in run"); }
}
