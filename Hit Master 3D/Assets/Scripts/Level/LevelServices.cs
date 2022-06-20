using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelServices : MonoBehaviour
{
    [SerializeField] private float _delayRestartLevel;

    private bool _isStart = false;

    public delegate void LevelStartHandler ();
    public static event LevelStartHandler OnStart; 

    private static LevelServices instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void OnEnable() 
    {
        PlayerInputListener.OnTouch += StartLevel;
        Waypoint.OnTriger += ReloadLevel;
    }
    
    private void OnDisable() 
    {
        PlayerInputListener.OnTouch -= StartLevel;
        Waypoint.OnTriger -= ReloadLevel;
    }
    
    private void StartLevel(Touch touch) 
    {
        
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
            StartCoroutine(ReloadLevel());
    }

    private IEnumerator ReloadLevel() 
    {
        yield return new WaitForSeconds(_delayRestartLevel);
        _isStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}
