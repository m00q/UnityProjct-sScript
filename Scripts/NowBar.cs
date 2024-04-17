using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowBar : MonoBehaviour
{
    public GameManager gm;
    float expValue;

    public Slider m_Value;

    private void Awake()
    {
        
    }

    void Update()
    {
        if (gm.m_PlayerLevel > gm.m_NeedExp.Count)
            transform.parent.gameObject.SetActive(false);
        float expScale = gm.m_PlayerExp / (float)gm.m_NeedExp[gm.m_PlayerLevel -1];
        expValue = expScale;
        m_Value = GetComponent<Slider>();
        m_Value.value = expValue;
    }
}
