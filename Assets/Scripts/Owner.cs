using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Owner : MonoBehaviour
{
    private const string loseScene = "LoseScene";
    private const string pathToValuesCanvas = "Canvas/ValuesCanvas";
    private const int restTime = 2500;


    public int visits;
    public int timer;
    public int visitTime;
    public bool active;
    public bool isPlaying;
    public bool isWatching;
    public bool isAlerted;

    private ValuesCanvas valuesCanvas;

    public VideoPlayer videoPlayerOpen;
    public VideoPlayer videoPlayerClose;
    public VideoPlayer videoPlayerAlert;

    void Start()
    {
        valuesCanvas = GameObject.Find(pathToValuesCanvas).GetComponent<Canvas>().GetComponent<ValuesCanvas>();

        gameObject.GetComponent<SpriteRenderer>().enabled = active;
        visitTime = RandomizeTime();

        var videoPlayers = GetComponents<VideoPlayer>();
        videoPlayerOpen = videoPlayers[0];
        videoPlayerClose = videoPlayers[1];
        videoPlayerAlert = videoPlayers[2];
        videoPlayerOpen.Prepare();
        videoPlayerClose.Prepare();
        videoPlayerAlert.Prepare();
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = active;

        if (!isAlerted)
        {
            if (active)
            {
                if (!isPlaying)
                {
                    videoPlayerOpen.Play();
                    isPlaying = true;
                }
                if (timer >= 200)
                {
                    isWatching = true;
                }
                CheckLose();
                if (timer >= visitTime)
                {
                    active = false;
                    visitTime = RandomizeTime();
                    timer = 0;
                    videoPlayerClose.Play();
                    videoPlayerOpen.Stop();
                    isPlaying = false;
                    isWatching = false;
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
                    visitTime = RandomizeTime();
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
    }

    int RandomizeTime()
    {
        return Random.Range(300, 1000);
    }

    void CheckLose()
    {
        double sumStealth = GlobalData.stealthCount == 0 ? 101 : GlobalData.moldCount / GlobalData.stealthCount;

        if (sumStealth > 100 && isWatching)
        {
            isAlerted = true;
            videoPlayerOpen.Stop();
            videoPlayerClose.Stop();
            videoPlayerAlert.loopPointReached += videoPlayerAlertEnd;
            Invoke("PlayAlert", 1);
        }
    }
    void videoPlayerAlertEnd(VideoPlayer source)
    {
        SceneManager.LoadScene(loseScene);
    }

    void PlayAlert()
    {
        videoPlayerAlert.Play();
    }
}
