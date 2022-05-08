using System.Collections;
using UnityEngine;

public class House : Building
{
    [SerializeField] public int maxInhabitants = 200;
    [SerializeField] private float tickSpeed = 0.3f;
    private float _timePassed;

    private void Update()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > tickSpeed && inhabitants < maxInhabitants)
        {
            _timePassed = 0;
            resources.AddPopulation(2);
        }
    }
}
