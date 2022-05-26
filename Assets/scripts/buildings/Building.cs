using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
     public int id;

     [Header("Building Data")] [SerializeField]
     public float cost = 200;
     [SerializeField] public float inhabitants = 20;
     
     private void Awake()
     {
          id = GetInstanceID();
     }

     private void Start(){
          //Id is only available from here
          EventManager.current.OnBuild(id);
     }
}


