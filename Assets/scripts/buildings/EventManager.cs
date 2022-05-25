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

  public event Action<int, RaycastHit> OnBuildEvent;
  
  public void OnBuild(int id, RaycastHit hit){
      OnBuildEvent?.Invoke(id, hit);
  }
}