using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FactoryData", order = 1)]
public class FactoryData : ScriptableObject
{ 
     public float moneyOnClick = 200;
     public float passiveIncome = 20;
     public int populationDeathOnClick = 20;
     public int populationRemovedOnBuild = 10;
     public int populationDecreaseOnTick = 20;
}
