using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
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

    private void OnClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
        //check if the ray has hit something
        if (!Physics.Raycast(ray, out hit)) return;
        print("click");
        BuildingClickEvent?.Invoke(this, new BuildingArgs { hitData = hit} );
    }
    
}
