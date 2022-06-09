using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class House : Building
{
    [SerializeField] public int maxInhabitants = 200;
    [SerializeField] private int populationToAdd = 20;
    [SerializeField] private int populationToAddOnBuild = 30;

    public override void Start(){
        base.Start();
        
        EventManager.current.OnClickEvent += OnHouseClick;
        EventManager.current.OnBuildEvent += OnBuild;
        EventManager.current.OnTickEvent += OnTick;
    }

    private void Update(){
        Resources.current.AddPopulation(2);
    }

    private void OnHouseClick(int id, RaycastHit hit){
        if (id != this.id) return;

        Resources.current.AddPopulation(2);
    }

    /*todo: id = different form the building spot id so the function wont be executed
     Function seems to not get called 
    */
    private void OnBuild(int id){
        if(id != this.id) return;
        print("passed id");
        
        Resources.current.AddMaxPopulation(populationToAddOnBuild);
        Resources.current.SubTractMoney(cost);

        EventManager.current.OnBuildEvent -= OnBuild;
    }

    private void OnTick(){
        Resources.current.AddPopulation(populationToAdd);   
    }
    
}
