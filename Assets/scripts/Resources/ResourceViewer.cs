using TMPro;
using UnityEngine;

public class ResourceViewer : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text populationText;

    private Resources _resources;
    
    private void Start()
    {
        _resources = FindObjectOfType<Resources>();

        if (_resources == null)
        {
            Debug.LogWarning("Resource manager not found");
        }
    }

    private void Update()
    {
        //Update the resources ui
        moneyText.text = "Money: " + Resources.current.money;
        populationText.text = "Population: " + Resources.current.globalPopulation + " / " + Resources.current.maxPopulation;
    }
}
