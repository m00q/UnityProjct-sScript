using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnime : MonoBehaviour
{
    /*
    RectTransform m_Move;

    private void Update()
    {
        // 80~40
        m_Move
    }
    */
    public RectTransform m_Move;
    public float speed = 5f; // 이동 속도 조절

    private bool isMovingUp = true; // 현재 이동 방향

    private void Update()
    {
        // 현재 PosY 값을 가져옴
        float currentPosY = m_Move.anchoredPosition.y;
        Debug.Log(currentPosY);
        // 이동 방향에 따라 PosY 값을 조절
        if (isMovingUp)
        {
            currentPosY += speed * Time.unscaledDeltaTime;
        }
        else
        {
            currentPosY -= speed * Time.unscaledDeltaTime;
        }

        // PosY가 40보다 작거나 80보다 크면 이동 방향을 변경
        if (currentPosY >= 80f)
        {
            currentPosY = 80f;
            isMovingUp = false;
        }
        else if (currentPosY <= 40f)
        {
            currentPosY = 40f;
            isMovingUp = true;
        }

        // 새로운 PosY 값을 적용
        m_Move.anchoredPosition = new Vector2(m_Move.anchoredPosition.x, currentPosY);
    }
}
