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
    private float _timePassed;

    private void Start(){
        EventManager.current.OnClickEvent += OnClick;
    }

    private void generateMoney(){
        if (tickSpeed < _timePassed) return;

        _timePassed = 0;

        resources.AddMoney(passiveIncome);
    }

    private void OnClick(int id, RaycastHit hit){
        if (id != this.id) return;

        var factory = hit.transform.GetComponent<Factory>();

        resources.AddMoney(factory.moneyOnClick);

        _timePassed = Time.deltaTime;
    }

    private void OnBuild(int id, RaycastHit hit){
        if (id != this.id) return;
        
        resources.SubTractMoney(3000);
        resources.maxPopulation -= 20;
        resources.globalPopulation -= 30;
    }

}
