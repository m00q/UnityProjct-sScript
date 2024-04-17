using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeViewer : MonoBehaviour
{
    string m_Text;
    TextMeshProUGUI m_cText;
    void Start()
    {
        m_cText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.gameStart)
        {
            m_Text = GameManager.gameManager.Timmer();
            m_cText.text = m_Text;
        }

    }


}
