using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UseSlider : MonoBehaviour
{
    Slider s;

    private void Start()
    {
        s = GetComponent<Slider>();
    }
    public void CalcValrue()
    {
        float expScale = GameManager.gameManager.m_PlayerExp / (float)GameManager.gameManager.m_NeedExp[GameManager.gameManager.m_PlayerLevel - 1];
        s.value = expScale;
    }
}
