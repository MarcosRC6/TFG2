using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{

    [SerializeField] private int min;
    [SerializeField] private int seg;
    public GameObject gameOver;

    private int m, s;

    [SerializeField] private TMP_Text timerText;

    private static TimeController instance;

    public static TimeController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        m = min;
        s = seg;
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    public void StopTimer()
    {
        CancelInvoke();
    }

    private void UpdateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                gameOver.SetActive(true);
            }
            else
            {
                m--;
                s = 59;
            }
        }

        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    private void WriteTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopTimer();
        StartTimer();
    }
    /*
    [SerializeField] private int min;
    [SerializeField] private int seg;
    public GameObject gameOver;

    private int m, s;

    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        startTimer();
    }

    public void startTimer()
    {
        m = min;
        s = seg;
        writeTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    public void stopTimer()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void UpdateTimer()
    {
        s--;
            if(s<0)
        {
            if (m == 0)
            {
                gameOver.SetActive(true);
            }
            else
            {
                m--;
                s = 59;
            }
        }
        writeTimer(m,s);
        Invoke("UpdateTimer", 1f);
    }

    private void writeTimer(int m, int s)
    {
        if(s<10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }*/
}
