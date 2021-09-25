using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayState : IClockState
{
    public void Execute(clock clock)
    {
        //continuar o iniciar la cuenta abajo

        if (clock.isPaused)
        {
            clock.isPaused = false;
            clock.timeScale = clock.timeScaleWhenPaused;
        }
    }
}
