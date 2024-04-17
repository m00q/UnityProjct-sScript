using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingSkill : MonoBehaviour
{
    public List<GameObject> m_DropCube = new List<GameObject>();
    //public Scanner sc;

    public int m_SkillLv;
    public float m_SkillDamage;

    public Vector3 m_MakeVector;
    public Vector3 m_Higher;

    public Quaternion m_Angle;
    public float m_AngleValue;

    public Vector3 m_SavePosition;

    public float m_Interval;

    public GameObject m_ugo_Meteor0;
  
    void Awake()
    {
        StartCoroutine(StartTimerCoroutine());
        LvUpDropingSkill();
    }



    public void LvUpDropingSkill()
    {
        if (m_SkillLv < 6)
            m_SkillLv = Skills.m_DropSkillLv;

        switch (m_SkillLv)
        {
            case 1:
                m_ugo_Meteor0.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                m_Interval = 2.5f;
                m_ugo_Meteor0.transform.localScale = new Vector3(2f, 2f, 2f);
                break;

            case 3:
                
                break;

            case 4:
                m_Interval = 2f;
                m_ugo_Meteor0.transform.localScale = new Vector3(3f, 3f, 3f);
                break;

            case 5:
                m_ugo_Meteor0.transform.localScale = new Vector3(6f, 6f, 6f);
                break;
            default:
                m_SkillDamage = 1;

                break;
        }
    }

    //public void

    void Update()
    {
        if (!GameManager.gameManager.gameStart)
            return;
        LvUpDropingSkill();
        m_SkillLv = Skills.m_DropSkillLv;
        if (Scanner.m_NearTarget != null)
        {
            m_SavePosition = Scanner.m_NearTarget.position;
            m_MakeVector = Scanner.m_NearTarget.position;
        }
        else
        {
         
        }
        StartTimerCoroutine();
    }


    IEnumerator StartTimerCoroutine()
    {
        while (true)
        {
            //if (sc != null && sc.m_NearTarget != null)
            {

                yield return new WaitForSeconds(m_Interval);
                //DoMake();
                DoSet();
                m_ugo_Meteor0.SetActive(true);
                yield return new WaitForSeconds(2f);
                m_ugo_Meteor0.SetActive(false);
                /*
                if (m_SkillLv >= 3)
                {
                    yield return new WaitForSeconds(0.6f); // 0.6√ ¿« ¿Œ≈Õπ˙
                    //DoMake();
                    DoSet();
                    m_ugo_Meteor1.SetActive(true);
                    yield return new WaitForSeconds(2f);
                    m_ugo_Meteor1.SetActive(false);
                }
                if (m_SkillLv >= 5)
                {
                    yield return new WaitForSeconds(0.6f); // 0.6√ ¿« ¿Œ≈Õπ˙
                    //DoMake();
                    DoSet();
                    m_ugo_Meteor2.SetActive(true);
                    yield return new WaitForSeconds(2f);
                    m_ugo_Meteor2.SetActive(false);
                }
                */
            }
            //else
            {
            //    yield return null;
            }
        }
    }

    public void DoMake()
    {
        foreach (GameObject box in m_DropCube)
        {
            if (!box.activeSelf)
            {
                m_AngleValue = Random.Range(10f, 80f);
                m_Angle = Quaternion.Euler(0f, m_AngleValue, 0f);
                m_MakeVector += new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
                box.transform.position = m_MakeVector;
                box.transform.rotation = m_Angle;
                box.SetActive(true);

                break;
            }
        }
    }

    public void DoSet()
    {
        m_ugo_Meteor0.transform.position = m_MakeVector;

    }

}
