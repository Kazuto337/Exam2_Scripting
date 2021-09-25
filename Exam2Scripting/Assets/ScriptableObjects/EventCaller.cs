using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class EventCaller : ScriptableObject
{
    public event UnityAction _pause;
    public event UnityAction _continue;
    public event UnityAction _reset;

    public void Pause()
    {
        _pause?.Invoke();
    }

    public void Continue()
    {
        _continue?.Invoke();
    }

    public void Reset()
    {
        _reset?.Invoke();
    }
}
