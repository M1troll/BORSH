using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ValuesCanvas : MonoBehaviour
    {

        private const string keySavedMold = "SavedMold";
        private const string keySavedPassiveMold = "SavedPassiveMold";
        private const string keySavedMoldClick = "SavedMoldClick";
        private const string keySavedStealth = "SavedStealth";
        private const string pathToMoldText = "Canvas/ValuesCanvas/MoldText";
        private const string pathToStealthText = "Canvas/ValuesCanvas/StealthText";
        private const string mainScene = "MainScene";

        private Text moldText;
        private Text stealthText;

        public int moldCount;
        public int stealthCount = 100;

        public int addMoldPassiveCount = 1;
        public int addMoldPassiveInterval = 50;
        public int addMoldClickCount = 1;

        private int timer;

        void Awake()
        {
            LoadGame();
        }

        void Start()
        {
            moldText = GameObject.Find(pathToMoldText).GetComponent<Text>();
            moldText.text = "Плесень " + moldCount;
            stealthText = GameObject.Find(pathToStealthText).GetComponent<Text>();
            stealthText.text = "Скрытность " + stealthCount;
        }

        void FixedUpdate()
        {
            if (timer == addMoldPassiveInterval)
            {
                AddMold(addMoldPassiveCount);
                timer = 0;
            }

            timer++;
        }

        void OnDestroy()
        {
            SaveGame();
        }

        public void AddMold(int count)
        {
            moldCount += count;
            moldText.text = "Плесень " + moldCount;
        }

        public void SubstractMold(int count)
        {
            moldCount -= count;
            moldText.text = "Плесень " + moldCount;
        }

        public void AddStealth(int count)
        {
            stealthCount += count;
            stealthText.text = "Скрытность " + stealthCount;
        }

        public void SubstractStealth(int count)
        {
            stealthCount -= count;
            stealthText.text = "Скрытность " + stealthCount;
        }

        void SaveGame()
        {
            PlayerPrefs.SetInt(keySavedMold, moldCount);
            PlayerPrefs.SetInt(keySavedPassiveMold, addMoldPassiveCount);
            PlayerPrefs.SetInt(keySavedMoldClick, addMoldClickCount);
            PlayerPrefs.SetInt(keySavedStealth, stealthCount);
            PlayerPrefs.Save();
            Debug.Log("Game data saved!");
        }

        void LoadGame()
        {
            if (PlayerPrefs.HasKey(keySavedMold))
            {
                moldCount = PlayerPrefs.GetInt(keySavedMold);
                addMoldPassiveCount = PlayerPrefs.GetInt(keySavedPassiveMold);
                addMoldClickCount = PlayerPrefs.GetInt(keySavedMoldClick);
                stealthCount = PlayerPrefs.GetInt(keySavedStealth);
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
            moldCount = 0;
            addMoldPassiveCount = 1;
            addMoldClickCount = 1;
            stealthCount = 100;
            Start();
            SceneManager.LoadScene(mainScene);
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
}

