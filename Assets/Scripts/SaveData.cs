using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public const string keySavedMold = "SavedMold";
    public const string keySavedPassiveMold = "SavedPassiveMold";
    public const string keySavedMoldClick = "SavedMoldClick";
    public const string keySavedStealth = "SavedStealth";
    public const string keyActiveScene = "ActiveScene";
    public const string mainScene = "MainScene";
    public static void SaveGame()
    {
        PlayerPrefs.SetInt(keySavedMold, GlobalData.moldCount);
        PlayerPrefs.SetInt(keySavedPassiveMold, GlobalData.addMoldPassiveCount);
        PlayerPrefs.SetInt(keySavedMoldClick, GlobalData.addMoldClickCount);
        PlayerPrefs.SetInt(keySavedStealth, GlobalData.stealthCount);
        PlayerPrefs.SetString(keyActiveScene, GlobalData.ActiveScene);
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
            GlobalData.ActiveScene = PlayerPrefs.GetString(keyActiveScene);
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        GlobalData.ActiveScene = mainScene;
        SceneManager.LoadScene(GlobalData.ActiveScene);
        GlobalData.moldCount = 0;
        GlobalData.addMoldPassiveCount = 1;
        GlobalData.addMoldClickCount = 1;
        GlobalData.addMoldPassiveInterval = 50;
        GlobalData.stealthCount = 100;
        Debug.Log("Data reset complete");
    }

    void OnDestroy()
    {
        GlobalData.ActiveScene = SceneManager.GetActiveScene().name;
        SaveGame();
    }
    public void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            GlobalData.ActiveScene = SceneManager.GetActiveScene().name;
            SaveGame();
        }
    }

    void OnApplicationQuit()
    {
        GlobalData.ActiveScene = SceneManager.GetActiveScene().name;
        SaveGame();
    }
}
