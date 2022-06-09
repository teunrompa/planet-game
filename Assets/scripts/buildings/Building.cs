using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
     public int id;

     [Header("Building Data")] 
     [SerializeField] public float cost = 200;

     private void Awake(){
          id = GetInstanceID();
     }

     //Event has to be called form start and not awake because otherwise execution order of subscribers is not guaranteed
     public virtual void Start(){
          EventManager.current.OnBuild(id);
     }
}


