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


    private void Start()
    {
        _playerController.BuildingClickEvent += generateMoney;
    }

    private void generateMoney(object sender, PlayerController.BuildingArgs e)
    {
        RaycastHit hit = e.hitData;

        CheckForClick(hit);
        
        if (tickSpeed < _timePassed) return;
        
        _timePassed = 0;
        resources.AddMoney(passiveIncome);
    }

    void CheckForClick(RaycastHit hit)
    {
        if (hit.transform.GetComponent<Factory>() == null) return;
        var factory = hit.transform.GetComponent<Factory>();

        resources.AddMoney(factory.moneyOnClick);

        _timePassed = Time.deltaTime;

    }

}
