using UnityEngine;

public class LevelServices : MonoBehaviour
{
    public delegate void LevelStartHandler();
    public static event LevelStartHandler OnStart; 

    private void OnEnable() {
        PlayerInputListener.OnTouch += StartLevel;
    }
    
    public void StartLevel(Touch touch) {
        StartLevel();
    }

    public void StartLevel() {
        Debug.Log("Start level");
        
        OnStart.Invoke();
        PlayerInputListener.OnTouch -= StartLevel;
    }

    public void ReloadLevel() {
        Debug.Log("Reload level");
    }
}
