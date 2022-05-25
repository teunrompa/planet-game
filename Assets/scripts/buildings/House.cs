using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class House : Building
{
    [SerializeField] public int maxInhabitants = 200;
    [SerializeField] private float tickSpeed = 0.3f;
    private float _timePassed;

    private void Start(){
        EventManager.current.OnClickEvent += OnHouseClick;
        EventManager.current.OnBuildEvent += OnBuild;
    }

    private void Update(){
        _timePassed += Time.deltaTime;

        if (!(_timePassed > tickSpeed) || !(inhabitants < maxInhabitants)) return;
        _timePassed = 0;

        resources.AddPopulation(2);
    }

    private void OnHouseClick(int id, RaycastHit hit){
        if (id != this.id) return;

        resources.AddPopulation(2);
    }

    private void OnBuild(int id, RaycastHit hit){
        if (id != this.id) return;
        
        resources.AddMaxPopulation(30);
        resources.SubTractMoney(300);
    }

}
