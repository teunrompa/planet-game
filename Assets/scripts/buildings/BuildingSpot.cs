
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : Building
{
    [SerializeField] GameObject[] buildingTypes;

    [SerializeField] private int buildingSelector = 0;

    
    private void Start()
    {
        _playerController.BuildingClickEvent += Build;
        
        print("Buidling spot start is being called");
    }

    private void Update()
    {
        //Factory
        if (Input.GetKey(KeyCode.A)) {
            buildingSelector = 0;
        }
        //House
        if (Input.GetKey(KeyCode.S)) {
            buildingSelector = 1;
        }
    }

    private void Build(object sender, PlayerController.BuildingArgs e)
    {
        var raycastHit = e.hitData;
        
        if(raycastHit.transform.GetComponent<BuildingSpot>() == null) return;

        print(raycastHit);
        
        print("Building Placed");
    }
}
