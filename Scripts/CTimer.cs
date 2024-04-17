using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTimer : MonoBehaviour
{
    private static CTimer instance;
    // 이벤트를 통한 통신을 위한 델리게이트와 이벤트 정의
    public delegate void TimerEventHandler();
    public static event TimerEventHandler OnTimerTick;
    private bool isRunning = false;
    // 코루틴 인스턴스를 저장할 변수
    private Coroutine timerCoroutine;

    // 타이머 시작
    public void StartTimer(float duration)
    {
        if (!isRunning)
        {
            isRunning = true;
            timerCoroutine = StartCoroutine(TimerCoroutine(duration));
        }
        else
        {
            StopTimer();
            return;
        }
    }

    // 타이머 코루틴
    private IEnumerator TimerCoroutine(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            yield return null;
            timer += Time.deltaTime;

            // 타이머 틱마다 이벤트 호출
            OnTimerTick?.Invoke();
        }

        // 타이머 종료 후 초기화
        isRunning = false;
    }

    // 타이머 중지
    public void StopTimer()
    {
        if (isRunning)
        {
            StopCoroutine(timerCoroutine);
            isRunning = false;
        }
    }

}
