using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillLvUpGUI : MonoBehaviour
{
    public int m_BulletLv;
    public int m_ObitLv;
    public int m_DropSkillLv;

    public Button m_B1;
    public Button m_B2;
    public Button m_B3;

    public GameObject m_T1;
    public GameObject m_T2;
    public GameObject m_T3;

    TextMeshProUGUI t1;
    TextMeshProUGUI t2;
    TextMeshProUGUI t3;

    string t1SkillNm ;
    string t2SkillNm ;
    string t3SkillNm ;

    private void Awake()
    {

    }

    private void Start()
    {
        t1 = m_T1.GetComponent<TextMeshProUGUI>();
        t2 = m_T2.GetComponent<TextMeshProUGUI>();
        t3 = m_T3.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_BulletLv = Skills.m_BulletLv;
        m_ObitLv = Skills.m_ObitLv;
        m_DropSkillLv = Skills.m_DropSkillLv;
        
        t1.text = "BULLET\n" + m_BulletLv+"/5";
        t2.text = "OBITSKILL\n" + m_ObitLv + "/5";
        t3.text = "DROPSKILL\n" + m_DropSkillLv + "/5";

        if (m_BulletLv == 5)
            m_B1.interactable = false;
        if (m_ObitLv == 5)
            m_B2.interactable = false;
        if (m_DropSkillLv == 5)
            m_B3.interactable = false;
    }

    private void OnEnable()
    {
     
    }


    private void OnDisable()
    {
        
    }


}
