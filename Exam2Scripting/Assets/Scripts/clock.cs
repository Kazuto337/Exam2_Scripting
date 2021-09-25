using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]
    public int initialTime;

    [Tooltip("Escala de tiempo del reloj (1, normal, 0, pausa, 2, doble de rapido, -1, atras")]
    [Range(-10.0f,10.0f)]
    public float timeScale = 1;

    private Text myText;
    private float frameTimeWTimeScale = 0f;
    private float timeInSecondsToShow = 0f;
    private float timeScaleWhenPaused, initialTimeScale;
    private bool isPaused = false;

    //Desde aqui evento tiempo 0

    private bool time0Event = false;

    public delegate void time0Action();

    public static event time0Action atReaching0;


    private void Start()
    {
        initialTimeScale = timeScale;
        myText = GetComponent<Text>();

        timeInSecondsToShow = initialTime;

        updateClock(initialTime);
    }

    private void Update()
    {
        if (!isPaused)
        {
            frameTimeWTimeScale = Time.deltaTime * timeScale;

            timeInSecondsToShow += frameTimeWTimeScale;
            updateClock(timeInSecondsToShow);
        }
    }

    public void updateClock(float timeInSeconds)
    {
        int minutes = 0;
        int seconds = 0;
        string clockText;

        if(timeInSeconds < 0)
        {
            timeInSeconds = 0;
        }

        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        clockText = minutes.ToString("00") + ":" + seconds.ToString("00");

        myText.text = clockText;

        //desde aqui evento a 0

        if (timeInSeconds <= 0 && !time0Event)
        {
            if(atReaching0 != null)
            {
                atReaching0();
            }
            time0Event = true;
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            timeScaleWhenPaused = timeScale;
            timeScale = 0;
        }
    }

    public void Continue()
    {
        if (isPaused)
        {
            isPaused = false;
            timeScale = timeScaleWhenPaused;
        }
    }

    public void RestetClock()
    {
        isPaused = false;
        time0Event = false; //Del evento
        timeScale = initialTimeScale;
        timeInSecondsToShow = initialTime;
        updateClock(timeInSecondsToShow);
    }
}
