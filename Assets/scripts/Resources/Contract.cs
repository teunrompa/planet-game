using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Contract : MonoBehaviour
{
    [SerializeField] public float moneyToReach;
    [SerializeField] private float deadline;
    
    private void Update(){
        deadline -= Time.deltaTime;
    }

    //Checks if the contract has the required amount off money reached
    public bool ContractMoneyReached(float currentMoney){
        return currentMoney >= moneyToReach;
    }

    //Checks if the deadline has reached 0
    public bool ContractDeadlineReached(){
        return deadline <= 0;
    }

    public float GetMoneyToReach(){
        return moneyToReach;
    }
}
