using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isInBuildMode;
    /*
     Building selector is in here because if
     we modify it we can garauntee it will
     at least always be consistent 
     */
    [SerializeField] public int buildingSelector;
    [SerializeField] public GameObject[] buildingTypes;
    
    private BuildingSpot[] _buildSpots;

    private void Start()
    {
        _buildSpots = FindObjectsOfType<BuildingSpot>();

        foreach (var buildingSpot in _buildSpots)
        {
            buildingSpot.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnClick();

        if (Input.GetKeyDown(KeyCode.B)) ToggleBuildMode();
        
        //Factory
        if (Input.GetKey(KeyCode.A)) buildingSelector = 0;
        
        //House
        if (Input.GetKey(KeyCode.S)) buildingSelector = 1;
    }

    public void ToggleBuildMode()
    {
        isInBuildMode = !isInBuildMode;
        
        //Make building spots visible
        _buildSpots = FindObjectsOfType<BuildingSpot>(true);
        foreach (var buildingSpot in _buildSpots)
        {
            buildingSpot.gameObject.SetActive(isInBuildMode);
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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //check if the ray has hit something
        if (!Physics.Raycast(ray, out var hit)) return;
        
        //Pass the rayCastHit to the hitData
        BuildingClickEvent?.Invoke(this, new BuildingArgs { hitData = hit} );
    }
    
    public void SetBuildingSelector(int id) {
        if(id < 0 || id > buildingTypes.Length) return;
        buildingSelector = id;
    }

    public void IncrementSelector() {
        if(buildingSelector < 0 || buildingSelector > buildingTypes.Length) return;        
        
        buildingSelector++;
    }

    public void DecrementSelector() {
        if(buildingSelector < 0 || buildingSelector > buildingTypes.Length) return;
        buildingSelector--;
    }
}
