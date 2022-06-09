using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current;
    
    [SerializeField] private bool isInBuildMode;
    [SerializeField] public int buildingSelector;
    [SerializeField] public GameObject[] buildingTypes;
    
    private BuildingSpot[] _buildSpots;

    private void Awake(){
        current = this;
    }

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
        foreach (var buildingSpot in _buildSpots){
            if (buildingSpot.isBuildOn) return;

            buildingSpot.gameObject.SetActive(isInBuildMode);
        }
    }

    private void OnClick()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //check if the ray has hit something
        if (!Physics.Raycast(ray, out var hit)) return;

        //check if hit was a building
        if(hit.transform.gameObject.GetComponent<Building>() == null) return;

        //Gets the buildingId
        int buildingId = GetBuildingId(hit);
        
        //Passes the building id and hitData also triggers the onClick event
        EventManager.current.OnClick(buildingId, hit);
    }
    
    //Checks if the building selector is between 0 or the max and sets it
    public void SetBuildingSelector(int id) {
        if(id < 0 || id > buildingTypes.Length) return;
        
        buildingSelector = id;
    }
    
    //Checks if the building selector is the max and increments it
    public void IncrementSelector() {
        if(buildingSelector > buildingTypes.Length) return;
        
        buildingSelector++;
    }
    //Checks if the building selector is greater than 0 and decrements it
    public void DecrementSelector() {
        if(buildingSelector < 0) return;
        
        buildingSelector--;
    }

    //Gets the building id from an RaycastHit
    private static int GetBuildingId(RaycastHit hit){
        return  hit.transform.gameObject.GetComponent<Building>().id;
    }
}
