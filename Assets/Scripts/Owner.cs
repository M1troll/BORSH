using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Owner : MonoBehaviour
{
    private const string loseScene = "LoseScene";
    private const string pathToValuesCanvas = "Canvas/ValuesCanvas";
    private const int restTime = 100;


    public int visits;
    public int timer;
    public int visitTime;
    public bool active;

    private ValuesCanvas valuesCanvas;

    void Start()
    {
        valuesCanvas = GameObject.Find(pathToValuesCanvas).GetComponent<Canvas>().GetComponent<ValuesCanvas>();

        gameObject.GetComponent<SpriteRenderer>().enabled = active;
        visitTime = RandomizeTime();
    }
    
    void FixedUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = active;

        if (active)
        {
            CheckLose();
            if (timer >= visitTime)
            {
                active = false;
                visitTime = RandomizeTime();
                timer = 0;
            }

            timer++;
        }
        else if (visits < 3)
        {
            if (timer >= visitTime)
            {
                visits++;
                active = true;
                timer = 0;
                visitTime = visitTime = Random.Range(100, 250);
            }
            timer++;
        }
        else
        {
            if (timer >= restTime)
            {
                visits = 0;
            }

            timer++;
        }
    }

    int RandomizeTime()
    {
        return Random.Range(50, 1000);
    }

    void CheckLose()
    {
        
        double sumStealth = valuesCanvas.stealthCount == 0 ? 101 : valuesCanvas.moldCount / valuesCanvas.stealthCount;

        if (sumStealth > 100)
        {
            SceneManager.LoadScene(loseScene);
        }
    }
}
