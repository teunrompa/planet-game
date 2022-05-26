using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resources : MonoBehaviour
{
    //public static Resources current;
    public float money = 200;
    public int globalPopulation = 20;
    public int maxPopulation;

    private House[] houses;

    public static Resources current;

    private void Start(){
        current = this;
        
        //Calculate the max inhabitants
        houses = FindObjectsOfType<House>();
        foreach (var house in houses){
            maxPopulation += house.maxInhabitants;
        }
    }

    public void AddMaxPopulation(int amount){
        maxPopulation += amount;
    }

    public void AddMoney(float amount){
        money += amount;
        globalPopulation--;
    }

    public void SubTractMoney(float amount){
        money -= amount;
    }

    public bool CanBuy(float cost){
        return cost < money;
    }

    public void AddPopulation(int amount){
        if (globalPopulation + amount < maxPopulation ){
            globalPopulation += amount;
            return;
        }
        
        globalPopulation = maxPopulation;
    }
}