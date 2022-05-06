using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Factory : Building
{
    [SerializeField] public float moneyOnClick = 200;
    [SerializeField] private float passiveIncome = 20;

    private void Start()
    {
        BuildingClickEvent += generateMoney;
        print(resources);
        StartCoroutine(PassiveIncome());
    }
    
    private void generateMoney(object sender, BuildingArgs e)
    {
        RaycastHit hit = e.hitData;

        if (hit.transform.GetComponent<Factory>() == null) return;
        var factory = hit.transform.GetComponent<Factory>();

        resources.AddMoney(factory.moneyOnClick);
    }

    IEnumerator PassiveIncome()
    {
        resources.money += passiveIncome;
        resources.globalPopulation -= 2;
        yield return new WaitForSeconds(1f);
    }

}
