using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseState : IClockState
{
    public void Execute(clock clock)
    {
        //pausar el contador

        if (!clock.isPaused)
        {
            clock.isPaused = true;
            clock.timeScaleWhenPaused = clock.timeScale;
            clock.timeScale = 0;
        }
    }
}
