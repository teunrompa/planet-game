using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
     public int id;

     [Header("Building Data")] 
     [SerializeField] public float cost = 200;

     //Event has to be called form start and not awake because otherwise execution order of subscribers is not guaranteed
     public virtual void Start(){
          id = GetInstanceID();

          EventManager.current.OnBuild(id);
     }


     private void OnDestroy(){
          EventManager.current.OnRemove(id);
     }
}


