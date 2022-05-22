using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoldText : MonoBehaviour
{
    private Text text;
    private const string keySavedMold = "SavedMold";
    private int moldCount;
    private int addCountPassive = 1;
    private int addPassiveInterval = 50;
    private int timer;

    void Awake()
    {
        LoadGame();
    }
    
    void Start()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text = "Плесень " + moldCount;
    }
    
    void FixedUpdate()
    {
        if (timer == addPassiveInterval)
        {
            moldCount += addCountPassive;
            text.text = "Плесень " + moldCount;
            timer = 0;
        }

        timer++;
    }

    void OnDestroy()
    {
        SaveGame();
    }

    public void AddMold(int addCount)
    {
        moldCount += addCount;
        text.text = "Плесень " + moldCount;
    }


    void SaveGame()
    {
        PlayerPrefs.SetInt(keySavedMold, moldCount);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey(keySavedMold))
        {
            moldCount = PlayerPrefs.GetInt(keySavedMold);
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    void ResetData()
    {
        PlayerPrefs.DeleteAll();
        moldCount = 0;
        Debug.Log("Data reset complete");
    }

    //public void OnApplicationPause(bool pauseStatus)
    //{
    //    if (pauseStatus)
    //    {
    //        SaveGame();
    //    }
    //}
}
