using System;
using UnityEngine;

public class Building : MonoBehaviour
{
     [Header("Building Data")] 
     [SerializeField] private float cost = 200;
     [SerializeField] public float inhabitants = 20;

     public GameObject resourceManager;
     public Resources resources;

     private void Awake()
     {
          resourceManager = GameObject.Find("ResourceManager");
          resources = resourceManager.GetComponent<Resources>();
     }

     private void Update()
     {
          if (Input.GetMouseButtonDown(0))
          {
               OnClick();
          }
     }

     //Building Click event
     public event EventHandler<BuildingArgs> BuildingClickEvent;

     //Arguments for onClick
     public class BuildingArgs : EventArgs
     {
          public RaycastHit hitData;
     }
     
     public void OnClick()
     {
          RaycastHit hit;
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
          //check if the ray has hit something
          if (!Physics.Raycast(ray, out hit)) return;
          BuildingClickEvent?.Invoke(this, new BuildingArgs { hitData = hit} );
     }
}


