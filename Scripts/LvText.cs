using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvText : MonoBehaviour
{
    TextMeshProUGUI t1;

    private void Start()
    {
        t1 = this.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        t1.text = "" + GameManager.gameManager.m_PlayerLevel;
    }
}
