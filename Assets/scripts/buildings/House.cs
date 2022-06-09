using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class House : Building
{
    public HouseData data;

    void Awake(){
        EventManager.current.OnClickEvent += OnHouseClick;
        EventManager.current.OnBuildEvent += OnBuild;
        EventManager.current.OnTickEvent += OnTick;
    }

    private void OnHouseClick(int id, RaycastHit hit){
        if (id != this.id) return;

        Resources.current.AddPopulation(2);
    }
    
    //fixme id's mismatch
    private void OnBuild(int id){
        if(id != this.id) return;
        print("building house");

        Resources.current.AddMaxPopulation(data.populationToAddOnBuild);
        Resources.current.SubTractMoney(cost);

        EventManager.current.OnBuildEvent -= OnBuild;
    }

    private void OnTick(){
        Resources.current.AddPopulation(data.populationToAdd);   
    }
    
}
