using UnityEngine;

public class Factory : Building
{
    [SerializeField] public float moneyOnClick = 200;
    [SerializeField] private float passiveIncome = 20;
    [SerializeField] private int populationDeathOnClick = 40;
    [SerializeField] private int populationRemovedOnClick = 10;
    
    private void Start(){
        EventManager.current.OnClickEvent += OnClick;
        EventManager.current.OnBuildEvent += OnBuild;
        EventManager.current.OnTickEvent += OnTick;
    }

    private void OnClick(int id, RaycastHit hit){
        if (id != this.id) return;

        var factory = hit.transform.GetComponent<Factory>();

        Resources.current.AddMoney(factory.moneyOnClick);
        Resources.current.SubtractPopulation(populationDeathOnClick);
    }

    private void OnBuild(int id){
        if(id != this.id) return;
        
        Resources.current.SubTractMoney(cost);
        Resources.current.SubtractMaxPopulation(populationRemovedOnClick);
        Resources.current.SubtractPopulation(populationDeathOnClick);
    }

    private void OnTick(){
        Resources.current.AddMoney(passiveIncome);
    }

}
