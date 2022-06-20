using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//register to scriptable object
[CreateAssetMenu(fileName = "HouseData", menuName = "ScriptableObjects/Buildings/HouseData")]
public class HouseData : ScriptableObject
{
     public int maxInhabitants = 200;
     public int populationToAdd = 10;
     public int populationToAddOnBuild = 30;
}
