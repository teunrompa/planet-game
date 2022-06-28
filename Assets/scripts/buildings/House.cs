using System;
using UnityEngine;

public class House : Building
{
    public HouseData data;

    private void Awake(){
        EventManager.current.OnClickEvent += OnHouseClick;
        EventManager.current.OnBuildEvent += OnBuild;
        EventManager.current.OnTickEvent += OnTick;
        EventManager.current.OnRemoveEvent += OnRemove;
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

        EventManager.current.OnBuildEvent -= OnBuild;
    }

    private void OnTick(){
        Resources.current.AddPopulation(data.populationToAdd);   
    }

    private void OnRemove(int id){
        if(this.id != id) return;
        EventManager.current.OnTickEvent -= OnTick;
        EventManager.current.OnRemoveEvent -= OnRemove;
    }
    
}
