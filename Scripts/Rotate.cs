using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;  // 회전 속도
    public float m_higher;
    public int m_SkillLv;

    public GameObject[] orbits;



    void FixedUpdate()
    {     
        transform.position = GameManager.gameManager.player.transform.position + new Vector3(0f, m_higher, 0f);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        LvUpObitSkill();
    }

    void LvUpObitSkill()
    {
        m_SkillLv = Skills.m_ObitLv;
        if (m_SkillLv >= 6)
            m_SkillLv = 5;

        switch (m_SkillLv)
        {
            case 0:
                break;
            case 1:
                rotationSpeed = 180f;
                orbits[0].SetActive(true);
                break;

            case 2:
                rotationSpeed = 90f;
                orbits[1].SetActive(true);
                break;

            case 3:
                rotationSpeed = 90f;
                orbits[1].SetActive(false);
                orbits[2].SetActive(true);
                orbits[3].SetActive(true);
                break;

            case 4:
                rotationSpeed = 90f;
                orbits[1].SetActive(true);
                orbits[2].SetActive(false);
                orbits[3].SetActive(false);
                orbits[4].SetActive(true);
                orbits[5].SetActive(true);
                break;

            case 5:
                rotationSpeed = 145f;
                break;
            default:

                break;
        }
    }

    private void Start()
    {
        foreach (GameObject obj in orbits)
        {
            obj.SetActive(false);
        }
    }
}