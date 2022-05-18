using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class House : Building
{
    [SerializeField] public int maxInhabitants = 200;
    [SerializeField] private float tickSpeed = 0.3f;
    private float _timePassed;

    private void Start()
    {
       _playerController.BuildingClickEvent += OnHouseClick;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        
        if (!(_timePassed > tickSpeed) || !(inhabitants < maxInhabitants)) return;
        _timePassed = 0;
        
        resources.AddPopulation(2);
    }


    private void OnHouseClick(object sender, PlayerController.BuildingArgs e)
    {
        RaycastHit hit = e.hitData;
        
        if(hit.transform.GetComponent<House>() == null) return;
        
        resources.AddPopulation(2);
    }

    protected override void Build(){
        throw new NotImplementedException();
    }
}
