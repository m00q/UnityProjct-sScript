using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public float m_Number;
    public bool m_GeterMode;
    public GameObject player;
    public Rigidbody m_Target;
    public Rigidbody rigid;
    
    private void Awake()
    {
        m_Number = 1f;
        m_GeterMode = false;
        player = GameManager.gameManager.player.gameObject;
    }
    private void FixedUpdate()
    {
        if (m_GeterMode)
            DoGatherExp();
    }
    public void OnTriggerEnter(Collider collision)
    {   
        switch (collision.gameObject.layer)
        {
            case 20: // 20번은 Cheack
                GameManager.gameManager.GetExp(m_Number);
                GameManager.gameManager.CheckExp();
                Dead();
                break;
        }

    }
    public void Dead()
    {
        Destroy(this.gameObject);
    }

    public void DoGatherExp()
    {
        rigid = this.GetComponent<Rigidbody>();
        m_Target = player.GetComponent<Rigidbody>();
        //뉴 백터는 높이 조절용
        Vector3 dirVec = (m_Target.position + new Vector3(0f, 0.3f, 0f)) - rigid.position;
        Vector3 nextVec = dirVec.normalized * 5f * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
    }

    public void DoGetering()
    {
        m_GeterMode = true;
    }


}
