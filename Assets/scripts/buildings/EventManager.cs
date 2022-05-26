using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
  //TODO: Move event code here
  public static EventManager current;

  private void Awake()
  {
     current = this;
  } 
  
  public event Action<int, RaycastHit> OnClickEvent;
  
  public void OnClick(int id, RaycastHit hit)
  {
      OnClickEvent?.Invoke(id, hit);
  }

  public event Action OnBuildEvent;
  
  public void OnBuild(){
      OnBuildEvent?.Invoke();
  }
}