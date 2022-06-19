using UnityEngine;

public class LevelServices : MonoBehaviour
{
    
    private bool _isStart = false;
    public delegate void LevelStartHandler ();
    public static event LevelStartHandler OnStart; 

    private void OnEnable() {
        PlayerInputListener.OnTouch += StartLevel;
    }
    
    private void OnDisable() {
        PlayerInputListener.OnTouch -= StartLevel;
    }
    
    public void StartLevel(Touch touch) {
        
        if(_isStart == true) return;
        StartLevel();
    }

    private void StartLevel() {
        Debug.Log("Start level");
        _isStart = true;
        OnStart.Invoke();
    }

    public void ReloadLevel() {
        Debug.Log("Reload level");
    }
}
