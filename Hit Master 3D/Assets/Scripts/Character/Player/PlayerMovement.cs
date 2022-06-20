using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour, IMovable
{

    private Player _player;

    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    
    private void Start() 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Player>();
    }

    public void Move() 
    {
        var waypoint  = _player.Waypoints.First(flag => flag.IsPlayerTake != true);
        NavMeshAgent.SetDestination(waypoint.transform.position);
    }
}
