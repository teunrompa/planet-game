using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public float money = 200;
    public int globalPopulation = 20;
    public int maxPopulation;

    private House[] houses;

    private void Start()
    {
       houses = FindObjectsOfType<House>();

       foreach (var house in houses)
       {
          maxPopulation += house.maxInhabitants;
       }
    }

    public void AddMoney(float amount)
   {
      money += amount;
   }

   public void AddPopulation(int amount)
   {
      globalPopulation += amount;
   }
}