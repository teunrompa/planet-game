using UnityEngine;

public class Resources : MonoBehaviour
{
    //static resources so you can access resources globally and it will all reference the same variable
    public static Resources current;
    
    public float money = 200;
    private int globalPopulation = 20;
    private int maxPopulation;

    [SerializeField] private float tickSpeed = 0.5f;
    private float timePassed;
    
    private House[] houses;
    
    private void Start(){
        current = this;
        
        //Calculate the max inhabitants
        houses = FindObjectsOfType<House>();
        foreach (var house in houses){
            maxPopulation += house.maxInhabitants;
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
}