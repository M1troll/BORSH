using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private const string pathToValuesCanvas = "Canvas/ValuesCanvas";

    private ValuesCanvas valuesCanvas;

    void Start()
    {
        valuesCanvas = GameObject.Find(pathToValuesCanvas).GetComponent<Canvas>().GetComponent<ValuesCanvas>();
    }

    void Update()
    {
        
    }
    
    public void Maggots()
    {
        const int cost = 100;
        const int passiveMold = 2;
        const int stealth = 10;

        if (valuesCanvas.stealthCount >= stealth && valuesCanvas.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            valuesCanvas.addMoldPassiveCount += passiveMold;
            valuesCanvas.SubstractStealth(stealth);
        }
    }

    public void IcebergLettuce()
    {
        const int cost = 50;
        const int passiveMold = 1;
        const int stealth = 15;

        if (valuesCanvas.addMoldPassiveCount >= passiveMold && valuesCanvas.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            valuesCanvas.AddStealth(stealth);
            valuesCanvas.addMoldPassiveCount -= passiveMold;
        }
    }

    public void DeadFlies()
    {
        const int cost = 25;
        const int moldClickCount = 5;
        const int stealth = 30;

        if (valuesCanvas.stealthCount >= stealth && valuesCanvas.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            valuesCanvas.addMoldClickCount += moldClickCount;
            valuesCanvas.SubstractStealth(stealth);
        }
    }

    public void Evolution()
    {

    }
}
