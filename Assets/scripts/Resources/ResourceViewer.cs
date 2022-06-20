using System;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Contract))]
public class ResourceViewer : MonoBehaviour
{
    public Contract contract;
    public TMP_Text moneyText;
    public TMP_Text populationText;

    private void LateUpdate(){

        //if maxPopulation is greater than current population update ui
        if (Resources.current.getMaxPopulation() >= Resources.current.getPopulation())
            populationText.text = "Population: " + Resources.current.getPopulation() + " / " +
                                  Resources.current.getMaxPopulation();
        
        if (contract == null) return;
        //execute contract code...
        
        print("Money to reach " + contract.GetMoneyToReach());
        
        moneyText.text = "Money: " + Resources.current.money + " / " + contract.GetMoneyToReach();

        if (contract.ContractMoneyReached(Resources.current.money)){
            print("Contract completed");
        }

        if (contract.ContractDeadlineReached() && !contract.ContractMoneyReached(Resources.current.money)){
            print("Mission failed planet will be terminated");
        }
    }
}
