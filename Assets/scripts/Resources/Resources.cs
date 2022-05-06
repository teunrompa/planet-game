using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public float money = 200;
    public int globalPopulation = 20;

   public void AddMoney(float amount)
   {
      money += amount;
   }

   public void AddPopulation(int amount)
   {
      globalPopulation += amount;
   }
}