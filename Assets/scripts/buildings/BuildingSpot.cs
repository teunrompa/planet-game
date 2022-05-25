using System;
using TMPro;
using UnityEngine;

public class BuildingSpot : Building
{
    //We use the player controller to determine the selected building
    private PlayerController _controller;
    private GameObject[] _buildingTypes;
    private int _buildingSelector;
    
    private void Start() {
        EventManager.current.OnClickEvent += Build;
        _controller = FindObjectOfType<PlayerController>();
        
        if (_controller == null){
            Debug.LogError("Player controller not found");
            return;
        }
        
        _buildingTypes = _controller.buildingTypes;
    }

    private void Update()
    {
        //Updates the selector
        _buildingSelector = _controller.buildingSelector;
    }

    private void Build(int id, RaycastHit hit){
        if (id != this.id) return;

        if(!resources.CanBuy(SelectBuilding().cost)) return;

        Instantiate(
            _buildingTypes[_buildingSelector],
            hit. transform.position,
            hit.transform.rotation
        );
        
        gameObject.SetActive(false);
        
        EventManager.current.OnBuild(id, hit);
    }
    
    private Building SelectBuilding(){
        Building buildingToPlace = _buildingTypes[_buildingSelector].GetComponent<Building>();
        return buildingToPlace;
    }
}
