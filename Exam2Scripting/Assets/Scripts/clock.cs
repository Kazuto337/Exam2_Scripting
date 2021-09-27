using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    public int initialTime;
    [Range(-10.0f,10.0f)]
    public float timeScale = 1;

    public Text myText;
    float frameTimeWTimeScale = 0f; //solyd
    public float timeInSecondsToShow = 0f;
    public float timeScaleWhenPaused, initialTimeScale;
    public bool isPaused = false;

    IClockState states;
    [SerializeField] EventCaller events;

    public float FrameTimeWTimeScale { get => frameTimeWTimeScale; set => frameTimeWTimeScale = value; } //solyd

    private void Awake()
    {
        initialTimeScale = timeScale;
        myText = GetComponent<Text>();

        timeInSecondsToShow = initialTime;

        UpdateClock(initialTime);
    }

    private void Update()
    {
        if (!isPaused)
        {
            FrameTimeWTimeScale = Time.deltaTime * timeScale;
            timeInSecondsToShow += FrameTimeWTimeScale;
            UpdateClock(timeInSecondsToShow);
        }
    }

    private void OnEnable()
    {
        events._pause += Stop;
        events._continue += Play;
        events._reset += ResetClock;
    }

    private void OnDisable()
    {
        events._pause -= Stop;
        events._continue -= Play;
        events._reset -= ResetClock;
    }

    public void Play()
    {
        states = new OnPlayState();
        states.Execute(this);
    }

    public void Stop()
    {
        states = new OnPauseState();
        states.Execute(this);
    }

    public void ResetClock()
    {
        states = new OnResetState();
        states.Execute(this);
    }

    public void UpdateClock(float timeInSeconds)
    {
        int minutes = 0;
        int seconds = 0;
        string clockText;

        if (timeInSeconds < 0)
        {
            timeInSeconds = 0;
        }

        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        clockText = minutes.ToString("00") + ":" + seconds.ToString("00");

        myText.text = clockText;
    }
}
