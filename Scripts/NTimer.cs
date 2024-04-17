using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTimer : MonoBehaviour
{
    public delegate void TimerEventHandler();
    //public event TimerEventHandler OnTimerTick;

    private float duration;
    private float elapsed;
    private bool isRunning;

    public void StartTimer(float duration)
    {
        if (!isRunning)
        {
            this.duration = duration;
            elapsed = 0f;
            isRunning = true;
        }
        else
        {
            StopTimer();
            return;
        }
    }

    public void Update()
    {
        if (isRunning)
        {
            elapsed += Time.deltaTime;
            Debug.Log(elapsed);
            if (elapsed >= duration)
            {
                isRunning = false;
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
