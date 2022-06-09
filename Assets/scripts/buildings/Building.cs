using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
     public int id;

     [Header("Building Data")] 
     [SerializeField] public float cost = 200;

     public virtual void Start(){
          print("building start called");
          EventManager.current.OnBuild(id);
     }
}


