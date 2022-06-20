
using UnityEngine;

public sealed class PlayerBehaviorIdle : PlayerBehavior {

    public PlayerBehaviorIdle(Player player) : base(player) {}


    public override void Enter() 
    {
        PlayerInputListener.OnTouch += MakeShoot;
        Player.Animator.SetBool("isRun",false);
    }

    public override void Update() {}

    public override void Exit() 
    {
        PlayerInputListener.OnTouch -= MakeShoot;
    }

    private void MakeShoot(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        
        if (Physics.Raycast(ray,out hit, 15))
            Player.Shootable.Shoot(hit.transform,hit.point);
    }
}
