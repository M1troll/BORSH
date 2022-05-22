using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoldText : MonoBehaviour
{
    private Text text;
    private int count;
    private int addCountPassive = 1;
    private int addPassiveInterval = 50;
    private int timer;
    
    void Start()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text = "Плесень " + count;
    }
    
    void FixedUpdate()
    {
        if (timer == addPassiveInterval)
        {
            count += addCountPassive;
            text.text = "Плесень " + count;
            timer = 0;
        }

        timer++;
    }

    public void AddMold(int addCount)
    {
        count += addCount;
        text.text = "Плесень " + count;
    }
}
