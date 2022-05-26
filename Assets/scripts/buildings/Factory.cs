using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Factory : Building
{
    [SerializeField] public float moneyOnClick = 200;
    [SerializeField] private float passiveIncome = 20;
    [SerializeField] private float tickSpeed = 1f;
    private void Start(){
        EventManager.current.OnClickEvent += OnClick;
        EventManager.current.OnBuildEvent += OnBuild;
    }

    private void generateMoney(){
        resources.AddMoney(passiveIncome);
    }

    private void OnClick(int id, RaycastHit hit){
        if (id != this.id) return;

        var factory = hit.transform.GetComponent<Factory>();

        Resources.current.AddMoney(factory.moneyOnClick);
    }

    private void OnBuild(){
        Resources.current.SubTractMoney(cost);
        Resources.current.maxPopulation -= 20;
        Resources.current.globalPopulation -= 30;
    }

}
