using UnityEngine;

public class Factory : Building
{
    public FactoryData data;


    private void Awake(){
        EventManager.current.OnClickEvent += OnClick;
        EventManager.current.OnBuildEvent += OnBuild;
        EventManager.current.OnTickEvent += OnTick;
    }

    private void OnClick(int id, RaycastHit hit){
        if (id != this.id) return;

        var factory = hit.transform.GetComponent<Factory>();

        Resources.current.AddMoney(factory.data.moneyOnClick);
        Resources.current.SubtractPopulation(data.populationDeathOnClick);
    }

    private void OnBuild(int id){
        if(id != this.id) return;
        
        print("Building factory");
        
        Resources.current.SubtractMaxPopulation(data.populationRemovedOnBuild);
        Resources.current.SubtractPopulation(data.populationDeathOnClick);

        EventManager.current.OnBuildEvent -= OnBuild;
    }

    private void OnTick(){
        Resources.current.AddMoney(data.passiveIncome);
        Resources.current.SubtractPopulation(data.populationDecreaseOnTick);
    }

}
