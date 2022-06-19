
public abstract class PlayerBehavior : IBehavior
{
    private Player _player;

    public Player Player => _player;

    public PlayerBehavior(Player player) => _player = player;

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();
}
