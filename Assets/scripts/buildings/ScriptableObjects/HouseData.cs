using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//register to scriptable object
[CreateAssetMenu(fileName = "HouseData", menuName = "ScriptableObjects/Buildings/HouseData")]
public class HouseData : ScriptableObject
{
     public int maxInhabitants = 200;
     public int populationOnTick = 10;
     public int populationToAddOnBuild = 30;
}
