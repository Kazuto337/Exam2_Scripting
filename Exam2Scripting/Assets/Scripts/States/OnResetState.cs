using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResetState : IClockState
{
    public void Execute(clock clock)
    {
        //reiniciar el contador a 10

        clock.isPaused = false;
        clock.timeScale = clock.initialTimeScale;
        clock.timeInSecondsToShow = clock.initialTime;
        clock.UpdateClock(clock.timeInSecondsToShow);
    }
}
