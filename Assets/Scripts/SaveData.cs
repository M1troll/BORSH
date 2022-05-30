using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public const string keySavedMold = "SavedMold";
    public const string keySavedPassiveMold = "SavedPassiveMold";
    public const string keySavedMoldClick = "SavedMoldClick";
    public const string keySavedStealth = "SavedStealth";
    public const string mainScene = "MainScene";
    public static void SaveGame()
    {
        PlayerPrefs.SetInt(keySavedMold, GlobalData.moldCount);
        PlayerPrefs.SetInt(keySavedPassiveMold, GlobalData.addMoldPassiveCount);
        PlayerPrefs.SetInt(keySavedMoldClick, GlobalData.addMoldClickCount);
        PlayerPrefs.SetInt(keySavedStealth, GlobalData.stealthCount);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public static void LoadGame()
    {
        if (PlayerPrefs.HasKey(keySavedMold))
        {
            GlobalData.moldCount = PlayerPrefs.GetInt(keySavedMold);
            GlobalData.addMoldPassiveCount = PlayerPrefs.GetInt(keySavedPassiveMold);
            GlobalData.addMoldClickCount = PlayerPrefs.GetInt(keySavedMoldClick);
            GlobalData.stealthCount = PlayerPrefs.GetInt(keySavedStealth);
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    public void ResetData()
    {
        SceneManager.LoadScene(mainScene);
        PlayerPrefs.DeleteAll();
        GlobalData.moldCount = 0;
        GlobalData.addMoldPassiveCount = 1;
        GlobalData.addMoldClickCount = 1;
        GlobalData.addMoldPassiveInterval = 50;
        GlobalData.stealthCount = 100;
        Debug.Log("Data reset complete");
    }
}
