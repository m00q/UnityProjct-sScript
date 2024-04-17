using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_SkillVelocity;
    public float m_SkillDamage;
    public int m_SkillLv;
    public int m_SkillPiercing;
    //public int m_SkillPiercingLimit;

    //public Scanner scanner;

    Vector3 direction;

    bool SkillLife;
    public float timer;
    public float timeLimit;
    Rigidbody rig;

    Transform firePosition;

    private void Awake()
    {

        Vector3 tagetPosition;

        rig = GetComponent<Rigidbody>();
        //scanner = GetComponentInParent<Scanner>();
        firePosition = GetComponentInParent<Transform>();

        m_SkillLv = Skills.m_BulletLv;
        if (m_SkillLv >= 6)
            m_SkillLv = 5;
        if (Scanner.m_NearTarget != null)
        {
            tagetPosition = Scanner.m_NearTarget.position;
        }
        else
        {
            tagetPosition = firePosition.forward;
        }


        Shoot(tagetPosition);
        
    }




    private void Start()
    {   
        switch(m_SkillLv)
        {
            case 1:
                m_SkillDamage = 5;                
                m_SkillPiercing = 1;
                m_SkillVelocity = 13;
                break;

            case 2:
                m_SkillDamage = 10;
                m_SkillPiercing = 1;
                m_SkillVelocity = 15;
                break;

            case 3:
                m_SkillDamage = 20;
                m_SkillPiercing = 2;
                m_SkillVelocity = 17;
                break;

            case 4:
                m_SkillDamage = 35;
                m_SkillPiercing = 2;
                m_SkillVelocity = 20;
                break;

            case 5:
                m_SkillDamage = 50;
                m_SkillPiercing = 3;
                m_SkillVelocity = 25;
                break;
            default:
                m_SkillDamage = 50;
                m_SkillPiercing = 3;
                m_SkillVelocity = 25;
                break;
        }
             
    }

    private void FixedUpdate()
    {
        
        //Debug.Log("진입3");
        timer += Time.deltaTime;
        rig.velocity = direction * m_SkillVelocity;

        if (timer >= timeLimit)
        {
            Dead();
        }

    }

    void Shoot(Vector3 tagetPosition)
    {
        
        if (tagetPosition != null)
        {
            direction = tagetPosition - rig.position;
            direction.y = 0f;
            direction.Normalize();

            rig.velocity = direction * m_SkillVelocity;            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 9: //7번은 몬스터
            --m_SkillPiercing;
            if (m_SkillPiercing >= 0)
                return;
            Dead();
                break;
        }
    }
    


    void Dead()
    {
        Destroy(this.gameObject);
    }

}
