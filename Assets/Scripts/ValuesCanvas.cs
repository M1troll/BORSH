using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ValuesCanvas : MonoBehaviour
    {
        public const string pathToMoldText = "Canvas/ValuesCanvas/MoldText";
        public const string pathToStealthText = "Canvas/ValuesCanvas/StealthText";

        public Text moldText;
        public Text stealthText;

        private int timer;

        void Start()
        {
            SaveData.LoadGame();
            if (!GlobalData.ActiveScene.Equals("MainScene") && GlobalData.SceneTimer < 1)
            {
                GlobalData.SceneTimer++;
                SceneManager.LoadScene(GlobalData.ActiveScene);
            }
            else if (GlobalData.SceneTimer < 1)
            {
                GlobalData.SceneTimer++;
                SceneManager.LoadScene(GlobalData.ActiveScene);
            }

            moldText = GameObject.Find(pathToMoldText).GetComponent<Text>();
            moldText.text = "Плесень " + GlobalData.moldCount;
            stealthText = GameObject.Find(pathToStealthText).GetComponent<Text>();
            stealthText.text = "Скрытность " + GlobalData.stealthCount;
        }

        void FixedUpdate()
        {
            if (timer == GlobalData.addMoldPassiveInterval)
            {
                AddMold(GlobalData.addMoldPassiveCount);
                timer = 0;
            }

            timer++;
        }

        //void OnApplicationQuit()
        //{
        //    SaveData.SaveGame();
        //    GlobalData.ActiveScene = SceneManager.GetActiveScene().name;
        //}

        public void AddMold(int count)
        {
            GlobalData.moldCount += count;
            moldText.text = "Плесень " + GlobalData.moldCount;
        }

        public void SubstractMold(int count)
        {
            GlobalData.moldCount -= count;
            moldText.text = "Плесень " + GlobalData.moldCount;
        }

        public void AddStealth(int count)
        {
            GlobalData.stealthCount += count;
            stealthText.text = "Скрытность " + GlobalData.stealthCount;
        }

        public void SubstractStealth(int count)
        {
            GlobalData.stealthCount -= count;
            stealthText.text = "Скрытность " + GlobalData.stealthCount;
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

