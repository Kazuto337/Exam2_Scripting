using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockEvent : MonoBehaviour
{
    private void OnEnable()
    {
        clock.atReaching0 += ChangeToRed;
    }

    private void OnDisable()
    {
        clock.atReaching0 -= ChangeToRed;
    }

    void ChangeToRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
