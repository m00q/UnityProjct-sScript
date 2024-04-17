using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public List<GameObject> m_SkillList;
    public bool[] m_SkillLive;
    
    public Scanner scanner;

    static public int m_BulletLv;
    public int m_BulletMaxLv;
    public float m_BullatTimer;
    public float m_BullatTimerLimit;
    public float m_BulletDm;

    static public int m_ObitLv;
    public int m_ObitMaxLv;
    public float m_ObitDm;

    static public int m_DropSkillLv;
    public int m_DropSkillMaxLv;
    public float m_DropSkillDm;

    public enum m_GameSkill { BULLET, OBITSKILL, DROPSKILL, __count };

    private void Awake()
    {
        //GetSkill(0);
        m_BulletMaxLv = 5;
        m_BulletLv = 1;
        m_BulletDm = 10;
        m_BullatTimerLimit = 2f;

        m_ObitMaxLv = 5;

        m_DropSkillMaxLv = 5;
    }

    private void FixedUpdate()
    {
        if (GameManager.gameManager.curGUIState != 1)
            return;

        if (m_BulletLv == 0)
            return;
        m_BullatTimer += Time.deltaTime;        
        if(m_BullatTimer >= m_BullatTimerLimit)
        {   
            GameObject bulletSkillInstance = Instantiate(m_SkillList[0], transform.position, transform.rotation, transform);
            //  Debug.Log(newSkillInstance);
            m_BullatTimer = 0;
        }

        //Debug.Log(m_BulletDm);
        //Debug.Log(m_ObitDm);
        //Debug.Log(m_DropSkillDm);
    }
    void GetSkill(int skillID)
    {
        m_SkillLive[skillID] = true;
    }

    public void BulletLvUp()
    {
        if (m_BulletLv <= m_BulletMaxLv)
            m_BulletLv++;
        else
        {
            return;
        }
        switch (m_BulletLv)
        {
            case 1:
                m_BulletDm = 10;
                m_BullatTimerLimit = 2f;
                break;
            case 2:
                m_BulletDm = 15;
                m_BullatTimerLimit = 2f;
                break;
            case 3:
                m_BulletDm = 20;
                m_BullatTimerLimit = 1.5f;
                break;
            case 4:
                m_BulletDm = 30;
                m_BullatTimerLimit = 1.3f;
                break;
            case 5:
                m_BulletDm = 40;
                m_BullatTimerLimit = 1.1f;
                break;
        }
        Time.timeScale = 1f;
        GameManager.gameManager.m_LvUpGUI.SetActive(false);    
    }

    public void ObitSkillLvUp()
    {
        if (m_ObitLv <= m_ObitMaxLv)
            m_ObitLv++;
        else
        {
            return;
        }
        switch (m_ObitLv)
        {
            case 1:
                GameObject bulletSkillInstance = Instantiate(m_SkillList[1]);
                m_ObitDm = 10;
                break;
            case 2:
                m_ObitDm = 15;
                break;
            case 3:
                m_ObitDm = 25;
                break;
            case 4:
                m_ObitDm = 30;
                break;
            case 5:
                m_ObitDm = 35;
                break;
        }
        Time.timeScale = 1f;
        GameManager.gameManager.m_LvUpGUI.SetActive(false);
    }

    public void DropSkillLvUp()
    {
        if (m_DropSkillLv <= m_DropSkillMaxLv)
            m_DropSkillLv++;
        else
        {
            return;
        }
        switch (m_DropSkillLv)
        {
            case 1:
                GameObject dropSkillInstance = m_SkillList[2];
                dropSkillInstance.SetActive(true);
                m_DropSkillDm = 20;
                break;
            case 2:
                m_DropSkillDm = 30;
                break;
            case 3:
                m_DropSkillDm = 40;
                break;
            case 4:
                m_DropSkillDm = 50;
                break;
            case 5:
                m_DropSkillDm = 80;
                break;
        }
        Time.timeScale = 1f;
        GameManager.gameManager.m_LvUpGUI.SetActive(false);
    }


}

/*
void Shoot()
{

    if (scanner.m_NearTarget != null)
    {
        Vector3 direction = closestEnemyPosition.position - transform.position;
        GameObject objBullet = Instantiate(prefabSkill);

        objBullet.transform.position = firePoint.position;
        objBullet.transform.rotation = transform.rotation;// 현재 오브젝트의 방향을 총알의 회전 값으로 설정

        objBullet.GetComponent<Rigidbody>().AddForce(direction * 100f);

    }
    else
    {
        // 적이 없을 경우 전방으로 쏘는 코드
        GameObject objBullet = Instantiate(prefabSkill);
        objBullet.transform.position = firePoint.position;
        objBullet.transform.rotation = firePoint.rotation; // 전방으로 회전
        objBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200f);
    }

}
*/

