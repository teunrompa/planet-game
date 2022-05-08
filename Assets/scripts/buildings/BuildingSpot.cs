
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : Building
{
    [SerializeField] GameObject[] buildingTypes;

    [SerializeField] private int buildingSelector = 0;
    
    private void Start()
    {
        BuildingClickEvent += Build;
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

    private void Build(object sender, BuildingArgs e)
    {
        var raycastHit = e.hitData;
        
        print(raycastHit);
        
        Instantiate(buildingTypes[buildingSelector], raycastHit.transform.position, raycastHit.transform.rotation);
        print("Building Placed");
    }
}
