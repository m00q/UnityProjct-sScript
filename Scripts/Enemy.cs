using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem m_uptc_Effect;
    public GameObject m_ugo_Effect;


    public float m_Speed;
    public Rigidbody m_Target;

    public bool m_IsLive = true;

    public Rigidbody rigid;

    public float m_EnemyHp;
    public float m_EnemyDamage;
    public GameObject player;
    public GameObject m_EXP_Prefeb;
    public GameObject m_DropItemKind;
    public Skills m_Skills;

    public float m_DropProbability;

    public SkinnedMeshRenderer color;

    public Vector3 m_ForwardDirection;
    public float m_DistanceToMove = 0.2f;
    public bool isMutekiActive = true;
    public Collider m_ColliderMuteki;
    //public 
    float m_RotationSpeed = 90f;

    //public float acceleration = 2.0f;
    //public float minDistance = 1.0f;

    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameManager.gameManager.player.gameObject;
        GameObject skillsGameObject = GameObject.Find("Skills");
        m_Skills = skillsGameObject.GetComponent<Skills>();
        m_ColliderMuteki = GetComponent<Collider>();

    }
    void Start()
    {
        color = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid = this.GetComponent<Rigidbody>();
        m_Target = player.GetComponent<Rigidbody>();
        m_ForwardDirection = transform.forward;
        

        if (!m_IsLive)
        {
        return;
        }

        Vector3 dirVec = m_Target.position - rigid.position;
        //Debug.Log(dirVec);
        Vector3 nextVec = dirVec.normalized * m_Speed * Time.fixedDeltaTime;
        
        Quaternion targetRotation = Quaternion.LookRotation(nextVec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_RotationSpeed * Time.fixedDeltaTime);

        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector3.zero;
    }

    private IEnumerator SwitchMaterialsCoroutine()
    {
        color.material = color.materials[1];
        Debug.Log("진입");
        yield return new WaitForSeconds(0.3f);
        Debug.Log("탈출");
        color.material = color.materials[2];
        yield break;
    }

    private IEnumerator Muteki()
    {
        isMutekiActive = false;
        m_ColliderMuteki.isTrigger = false;
        Vector3 oppositeDirection = -m_ForwardDirection.normalized;
        oppositeDirection.y = 0;
        transform.position = transform.position + oppositeDirection * m_DistanceToMove;
        yield return new WaitForSeconds(1f);
        m_ColliderMuteki.isTrigger = true;
        isMutekiActive = true;
        yield break;
    }

    void Demeged(float demege)
        {
        //Debug.Log(demege);

        Vector3 hight = transform.position;
        hight.y = 0.5f;
        GameObject m_ugo_EffectInstance = Instantiate(m_ugo_Effect, hight, Quaternion.identity);

        m_EnemyHp -= demege;
            
        //StartCoroutine(SwitchMaterialsCoroutine()); 미완성 코드 맞으면 색상변경 코루틴 호출
        if(isMutekiActive)
        StartCoroutine(Muteki());

        if (m_EnemyHp <= 0)
                {
                GameObject dropExp = Instantiate(m_EXP_Prefeb, transform.position - new Vector3(0f, 0f, 0f), Quaternion.Euler(-90f, 0f, 0f));
                dropExp.transform.parent = GameObject.Find("EXP").transform;
                    
                    if (RandomDrop(m_DropProbability))
                    {
                        GameObject dropItem = Instantiate(m_DropItemKind, transform.position + new Vector3(0f, 0.12f, 0f), Quaternion.Euler(-90f, 0f, 0f));
                    }

                Destroy(this.gameObject);
                }
        }
    bool RandomDrop(float dropProbability)
    {
        float randomValue = Random.Range(0f, 1f);

        // 랜덤 값이 확률보다 작으면 드롭
        return randomValue < dropProbability;
    }

        /*
        void OnGUI()
            {
                GUI.Label(new Rect(10, 10, 200, 20), "체력: " + m_EnemyHp.ToString());
            }
        */

        void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.layer)
            {
                case 8: // 8번은 player
                    AttackPlayer();
                    break;
            }
        }

            private void OnTriggerEnter(Collider other)
            {
                switch (other.gameObject.layer)
                {
                    case 13: // 13번은 스킬 LayerMask.NameToLayer("Skill")
                    string tag = other.gameObject.tag;

                        switch (tag)
                        {
                            case "Skill1":
                                Demeged(m_Skills.m_BulletDm);
                                break;
                            case "Skill2":
                                Demeged(m_Skills.m_ObitDm);
                                break;
                            case "Skill3":
                                Demeged(m_Skills.m_DropSkillDm);
                                break;
                        }
                Debug.Log(tag);
                        
                        break;
                }
            }

    public void DoMeteorDamege()
    {
        Demeged(m_Skills.m_DropSkillDm);
    }
        

    void OnCollisionStay(Collision collision)
        {
            switch (collision.gameObject.layer)
            {
               // case 13: // 13번은 스킬 LayerMask.NameToLayer("Skill")
                //    Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                //    float a = bullet.m_BulletDamage;
               //     Demeged(a);
               //     break;
                case 8: // 8번은 player
                    AttackPlayer();
                    break;
            }

           

        }
    void AttackPlayer()
    {
        GameManager.gameManager.player.m_PlayerHP -= m_EnemyDamage;
    }
}
