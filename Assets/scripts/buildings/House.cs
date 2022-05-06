using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;

public class House : Building
{
    [SerializeField] private int maxInhabitants = 200;
    [SerializeField] private float tickSpeed = 0.3f;
    private float _timePassed;

    private bool addingPopulation = false;
    
    private void Update()
    {
        if (inhabitants < maxInhabitants && !addingPopulation)
        {
            StartCoroutine(IncreasePopulation());
            addingPopulation = true;
        }
        else
        {
            inhabitants = maxInhabitants;
            StopCoroutine(IncreasePopulation());
            addingPopulation = false;
        }
    }


    private IEnumerator IncreasePopulation()
    {
        resources.AddPopulation(1);
        yield return new WaitForSeconds(.5f);
    }
}
