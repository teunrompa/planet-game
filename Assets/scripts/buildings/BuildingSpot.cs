using System;
using UnityEngine;

public class BuildingSpot : Building
{
    //We use the player controller to determine the selected building
    private PlayerController _controller;
    private GameObject[] _buildingTypes;
    private RaycastHit buildingThatGotHit;
    private int _buildingSelector;

    private void Start() {
        _playerController.BuildingClickEvent += BuildEvent;
        _controller = FindObjectOfType<PlayerController>();
        
        if (_controller == null){
            Debug.LogError("Player controller not found");
            return;
        }
        
        _buildingSelector = _controller.buildingSelector;
        _buildingTypes = _controller.buildingTypes;
    }

    void BuildEvent(object sender, PlayerController.BuildingArgs e){
        Build(e.hitData);
    }

    protected override void Build(RaycastHit hit){
        var raycastHit = e.hitData;
        
        if(raycastHit.transform.GetComponent<BuildingSpot>() == null) return;

        if(!resources.CanBuy(SelectBuilding().cost)) return;
        
        Building selectedBuilding = SelectBuilding();
        
        resources.SubTractMoney(selectedBuilding.cost);
        //Place the selected building
        
        Instantiate(
            _buildingTypes[_buildingSelector],
            raycastHit. transform.position,
            raycastHit.transform.rotation
        );
    }

    private Building SelectBuilding(){
        Building buildingToPlace = _buildingTypes[_buildingSelector].GetComponent<Building>();
        return buildingToPlace;
    }
}
