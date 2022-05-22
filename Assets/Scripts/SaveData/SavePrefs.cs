using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    private const string keySavedMold = "SavedMold";
    private int moldCount;
    void SaveGame()
    {
        PlayerPrefs.SetInt(keySavedMold, moldCount);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
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
}
