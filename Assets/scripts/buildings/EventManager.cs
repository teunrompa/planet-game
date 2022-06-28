using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake(){
        current = this;
    }

    public event Action<int, RaycastHit> OnClickEvent;

    public void OnClick(int id, RaycastHit hit){
        OnClickEvent?.Invoke(id, hit);
    }

    //int is buildingID
    public event Action<int> OnBuildEvent;

    public void OnBuild(int id){
        OnBuildEvent?.Invoke(id);
    }

    public event Action OnTickEvent;

    public void OnTick(){
        OnTickEvent?.Invoke();
    }

    public event Action<int> OnRemoveEvent;
    
    public void OnRemove(int id){
        OnRemoveEvent?.Invoke(id);
    }
}