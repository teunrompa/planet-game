using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Resources : MonoBehaviour
{
    //static resources so you can access resources globally and it will all reference the same variable
    public static Resources current;
    
    [SerializeField] public float money = 200;
    [SerializeField] private int globalPopulation = 20;
    [SerializeField] private int maxPopulation;

    [SerializeField] private float tickSpeed = 120f;
    private float timePassed;
    
    private House[] houses;

    private void Awake(){
        current = this;
    }

    private void Start(){
        //Calculate the max inhabitants
        houses = FindObjectsOfType<House>();
        foreach (var house in houses){
            maxPopulation += house.data.maxInhabitants;
        }
    }

    private void Update(){
        timePassed += Time.deltaTime;

        if (!(tickSpeed < timePassed)) return;
        timePassed = 0;
        
        EventManager.current.OnTick();
        
    }
    
    public int getPopulation(){
        return globalPopulation;
    }

    public int getMaxPopulation(){
        return maxPopulation;
    }

    public void AddMaxPopulation(int amount){
        maxPopulation += amount;
    }

    public void AddPopulation(int amount){
        if (globalPopulation + amount < maxPopulation ){
            globalPopulation += amount;
            return;
        }
        
        globalPopulation = maxPopulation;
    }
    
    public void SubtractPopulation(int amount){
        if (globalPopulation < 0) return;

        globalPopulation -= amount;
    }

    public void SubtractMaxPopulation(int amount){
        if(maxPopulation - amount < 0) return;

        maxPopulation -= amount;
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

    //Calculate the total amount off money added each tick
    public static float TotalMoneyAddedEachTick(){
        var factories = FindObjectsOfType<Factory>();

        return factories.Sum(factory => factory.data.passiveIncome);
    }

    //Calculate the total amount off population added each tick
    public static float TotalPopulationAddedEachTick(){
        var houses = FindObjectsOfType<House>();
        
        return houses.Sum(house => house.data.populationOnTick);
    }

    public static float TotalPopulationRemovedEachTick(){
        var factories = FindObjectsOfType<Factory>();

        return factories.Sum(factory => factory.data.populationDecreaseOnTick);
    }
}