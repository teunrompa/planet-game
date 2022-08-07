using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current;
    
    [SerializeField] private bool isInBuildMode;
    [SerializeField] private bool isInRemoveMode;
    [SerializeField] public int buildingSelector;
    [SerializeField] public GameObject[] buildingTypes;

    private BuildingSpot[] _buildSpots;

    [FormerlySerializedAs("uiButtons")] [SerializeField] private GameObject buildingTypeButtons;
    
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnClick();

        if (Input.GetKeyDown(KeyCode.B)) ToggleBuildMode();
        
        //Factory
        if (Input.GetKey(KeyCode.A)) buildingSelector = 0;
        
        //House
        if (Input.GetKey(KeyCode.S)) buildingSelector = 1;
    }

    public void ToggleBuildMode(){
        isInRemoveMode = false;
        
        isInBuildMode = !isInBuildMode;
        
        //Make building spots visible
        buildingTypeButtons.SetActive(isInBuildMode);
        ToggleBuildSpots(isInBuildMode);
    }

    private void ToggleBuildSpots(bool buildMode){
        
        //Get all buildSpots and make them active or inactive 
        _buildSpots = FindObjectsOfType<BuildingSpot>(true);
        
        foreach (var buildingSpot in _buildSpots){
            
            if(buildingSpot.isBuildOn) continue;
            
            buildingSpot.gameObject.SetActive(buildMode);
        }
    }
    
    //Switches between remove mode also turns off build mode 
    public void ToggleRemoveMode(){
        isInBuildMode = false;
        
        isInRemoveMode = !isInRemoveMode;

        ToggleBuildSpots(isInBuildMode);
    }
    
    private void OnClick()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //check if the ray has hit something
        if (!Physics.Raycast(ray, out var hit)) return;

        //check if hit was a building
        if(hit.transform.gameObject.GetComponent<Building>() == null) return;
        
        if (isInRemoveMode){
            RemoveBuilding(hit);
            return; //Cancels out the on click method
        }
        
        //Gets the buildingId
        int buildingId = GetBuildingId(hit);
        
        //Passes the building id and hitData also triggers the onClick event
        EventManager.current.OnClick(buildingId, hit);
    }

    
    //Destroy building
    private void RemoveBuilding(RaycastHit hit){
        //prevents removing building spots
        if (hit.transform.gameObject.GetComponent<BuildingSpot>() != null) return;
        
        Destroy(hit.transform.gameObject);

        //Search for buildingSpot in building types
        foreach (var buildingType in buildingTypes){
            if (buildingType.GetComponent<BuildingSpot>() == null) continue;

            //Instantiate the building spot at previous location
            Instantiate(buildingType, hit.transform.position, hit.transform.rotation);
        }
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
