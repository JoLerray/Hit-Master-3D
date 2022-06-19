using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelServices : MonoBehaviour
{
    
    private bool _isStart = false;

    public delegate void LevelStartHandler ();
    public static event LevelStartHandler OnStart; 

    private void OnEnable() {
        PlayerInputListener.OnTouch += StartLevel;
        Waypoint.OnTriger += ReloadLevel;
    }
    
    private void OnDisable() {
        PlayerInputListener.OnTouch -= StartLevel;
        Waypoint.OnTriger -= ReloadLevel;
    }
    
    private void StartLevel(Touch touch) {
        
        if(_isStart == true) return;
        StartLevel();
    }

    private void StartLevel()
    {
        _isStart = true;
        OnStart.Invoke();
    }

    private void ReloadLevel(Waypoint waypoint) 
    {
        if(waypoint.NextWaypoint == null) 
            ReloadLevel();
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
