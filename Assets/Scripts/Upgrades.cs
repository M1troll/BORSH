using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Upgrades : MonoBehaviour
{
    private const string pathToValuesCanvas = "Canvas/ValuesCanvas";
    private const string pathToDeadFliesButton = "Canvas/Panel/UpgradesCanvas/DeadFliesButton";
    private const string pathToEvolutionButton = "Canvas/Panel/UpgradesCanvas/EvolutionButton";
    private const string winScene = "WinScene";

    private ValuesCanvas valuesCanvas;
    
    public GameObject Maggot;

    public VideoPlayer videoPlayer;

    void Start()
    {
        valuesCanvas = GameObject.Find(pathToValuesCanvas).GetComponent<Canvas>().GetComponent<ValuesCanvas>();
        
        var button = GameObject.Find(pathToEvolutionButton).GetComponent<Button>();
        videoPlayer = button.GetComponent<VideoPlayer>();

    }
    
    public void Maggots()
    {
        const int cost = 50;
        const int passiveMold = 2;
        const int stealth = 10;

        if (GlobalData.stealthCount >= stealth && GlobalData.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            GlobalData.addMoldPassiveCount += passiveMold;
            valuesCanvas.SubstractStealth(stealth);
            AppearMaggot();
        }
    }

    public void AppearMaggot()
    {
        var position = new Vector3(Random.Range(-1.8f, 1.65f), Random.Range(-4.85f, -2.15f));
        Instantiate(Maggot, position, new Quaternion(0, 0, 0, 0));
    }

    public void IcebergLettuce()
    {
        const int cost = 75;
        const int passiveMold = 1;
        const int stealth = 40;

        if (GlobalData.addMoldPassiveCount >= passiveMold && GlobalData.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            valuesCanvas.AddStealth(stealth);
            GlobalData.addMoldPassiveCount -= passiveMold;
        }
    }

    public void DeadFlies()
    {
        const int cost = 100;
        const int moldClickCount = 5;
        const int stealth = 30;

        if (GlobalData.stealthCount >= stealth && GlobalData.moldCount >= cost)
        {
            valuesCanvas.SubstractMold(cost);
            GlobalData.addMoldClickCount += moldClickCount;
            valuesCanvas.SubstractStealth(stealth);
            var button = GameObject.Find(pathToDeadFliesButton).GetComponent<Button>();
            var audioSource = button.GetComponent<AudioSource>();
            audioSource.Play();
        }
    }



    public void Evolution()
    {
        const int cost = 1500;


        if (GlobalData.moldCount >= cost)
        {
            videoPlayer.Prepare();
            videoPlayer.loopPointReached += _videoPlayer_loopPointReached;

            Invoke("Play", 1);
        }
    }
    void _videoPlayer_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene(winScene);
    }

    void Play()
    {
        videoPlayer.Play();
    }
}
