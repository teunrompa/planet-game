using TMPro;
using UnityEngine;

public class ResourceViewer : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text populationText;

    private void Update()
    {
        //Update the resources ui
        if (Resources.current.getMaxPopulation() <= Resources.current.getPopulation()){
            populationText.text = "Population: " + Resources.current.getPopulation() + " / " + Resources.current.getMaxPopulation();
        }
        
        moneyText.text = "Money: " + Resources.current.money;
    }
}
