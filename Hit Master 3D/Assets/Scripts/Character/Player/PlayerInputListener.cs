using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputListener : MonoBehaviour
{
  public delegate void PlayerTouchHandler(Touch touch);
  public static event PlayerTouchHandler OnTouch;  
  
  private void Update() {
    
    GetTouchInput();
  }

  private void GetTouchInput() {

    if(Input.touchCount > 0) 
    {
        Touch touch = Input.GetTouch(0);
        OnTouch.Invoke(touch);
    }
  }
}
