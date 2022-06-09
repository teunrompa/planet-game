using UnityEngine;

public class Factory : Building
{
    [SerializeField] public float moneyOnClick = 200;
    [SerializeField] private float passiveIncome = 20;
    [SerializeField] private int populationDeathOnClick = 40;
    [SerializeField] private int populationRemovedOnBuild = 10;
    private const int populationDecreaseOnTick = 20;

    public override void Start(){
        base.Start();
        
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
        
        Resources.current.SubtractMaxPopulation(populationRemovedOnBuild);
        Resources.current.SubtractPopulation(populationDeathOnClick);

        EventManager.current.OnBuildEvent -= OnBuild;
    }

    private void OnTick(){
        Resources.current.AddMoney(passiveIncome);
        Resources.current.SubtractPopulation(populationDecreaseOnTick);
    }

}
