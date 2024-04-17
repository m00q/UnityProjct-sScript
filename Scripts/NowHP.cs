using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowHP : MonoBehaviour
{
    public GameManager gm;
    RectTransform a;
    float hpValue;
    float hpMax;
    float hpPersentage;

    private void Awake()
    {
        //expValue = gm.checkExp();
        
        
    }

    void Update()
    {

        hpValue = gm.player.m_PlayerHP;
        if (hpValue <= 0) 
        { 
        a.localScale = new Vector3(0f, 1f, 1f);
        return; // 피통0 예쁘게 정리
        }
        hpMax = gm.m_PlayerHp;
        hpPersentage = hpValue / hpMax;
        //Debug.Log("hpPersentage :" + hpPersentage);
        //Debug.Log("hpValue :" + hpValue);
        //Debug.Log("hpMax :" + hpMax);
        a = GetComponent<RectTransform>();
        a.localScale = new Vector3(hpPersentage, 1f, 1f);
    }
}
