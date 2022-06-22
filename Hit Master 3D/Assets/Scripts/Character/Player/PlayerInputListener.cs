using UnityEngine;

public class PlayerInputListener : MonoBehaviour
{
  public delegate void PlayerTouchHandler(Touch touch);
  public static event PlayerTouchHandler OnTouch;  
  
  private void Update() 
  {
    GetTouchInput();
    GetClickInput();
  }

  private void GetTouchInput() 
  {
    if(Input.touchCount > 0) 
    {
        Touch touch = Input.GetTouch(0);
        
        if(touch.phase == TouchPhase.Ended) 
          OnTouch.Invoke(touch);
    }
  }
  private void GetClickInput()
  {
    if (Input.GetKeyDown (KeyCode.Mouse0))
    {
      Touch touch = new Touch();
      touch.phase = TouchPhase.Ended;
      touch.position = Input.mousePosition;
      OnTouch.Invoke(touch);
    }
  }
}
