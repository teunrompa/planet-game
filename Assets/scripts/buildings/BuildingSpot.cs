using System;
using TMPro;
using UnityEngine;

public class BuildingSpot : Building
{
    //We use the player controller to determine the selected building
    private PlayerController _controller;
    
    private GameObject[] _buildingTypes;
    private int _buildingSelector;
    
    public bool isBuildOn = false;
    
    public override void Start() {
        base.Start();
        
        EventManager.current.OnClickEvent += Build;
        _controller = PlayerController.current;
        
        
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

        if(!Resources.current.CanBuy(SelectBuilding().cost)) return;

        Instantiate(
            _buildingTypes[_buildingSelector],
            hit. transform.position,
            hit.transform.rotation
        );

        Resources.current.SubTractMoney(SelectBuilding().cost);

        isBuildOn = true;
        //if there is a building placed then disable the game object
        gameObject.SetActive(!isBuildOn);
    }
    
    private Building SelectBuilding(){
        Building buildingToPlace = _buildingTypes[_buildingSelector].GetComponent<Building>();
        return buildingToPlace;
    }
}
