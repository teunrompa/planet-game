using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class House : Building
{
    [SerializeField] public int maxInhabitants = 200;
    [SerializeField] private int populationToAdd = 20;
    private float _timePassed;

    private void Start(){
        EventManager.current.OnClickEvent += OnHouseClick;
        EventManager.current.OnBuildEvent += OnBuild;
    }

    private void Update(){
        resources.AddPopulation(2);
    }

    private void OnHouseClick(int id, RaycastHit hit){
        if (id != this.id) return;

        resources.AddPopulation(2);
    }

    private void OnBuild(){
        resources.AddMaxPopulation(populationToAdd);
        resources.SubTractMoney(cost);
    }

}
