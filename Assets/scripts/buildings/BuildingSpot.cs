
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingSpot : Building
{
    [SerializeField] GameObject[] buildingTypes;

    [SerializeField] private int buildingSelector;

    private void Start()
    {
        _playerController.BuildingClickEvent += Build;
        
        print("Buidling spot start is being called");
    }

    private void Update()
    {
        //Factory
        if (Input.GetKey(KeyCode.A)) buildingSelector = 0;
        
        //House
        if (Input.GetKey(KeyCode.S)) buildingSelector = 1;
    }

    private void Build(object sender, PlayerController.BuildingArgs e)
    {
        var raycastHit = e.hitData;
        if(raycastHit.transform.GetComponent<BuildingSpot>() == null) return;

        Building buildingToPlace = buildingTypes[buildingSelector].GetComponent<Building>();
        
        //Check if you have enough money to buy the building
        if(!resources.CanBuy(buildingToPlace.cost)) return;
        
        resources.SubTractMoney(buildingToPlace.cost);
        
        //Place the selected building
        Instantiate(buildingTypes[buildingSelector], raycastHit.transform.position, raycastHit.transform.rotation);
    }
}
