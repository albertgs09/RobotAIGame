using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Action timerCallback;
    private float timer;

    public void SetTimer(float time, Action timerCallback)
    {
        this.timer = time;
        this.timerCallback = timerCallback;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (IsTimerComplete()) timerCallback();
        }
    }

    public bool IsTimerComplete()
    {
        return timer <= 0;
    }
}
