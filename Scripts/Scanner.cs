using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float m_ScanRange;
    public Transform m_Roca;
    public Vector3 m_FirePosition;

    public LayerMask m_TargetLayer;
    public RaycastHit[] m_Targets;
    static public Transform m_NearTarget;

    public float m_Radius = 5f;
       

    private void Awake()
    {
        m_Roca = this.transform;
    }
    private void FixedUpdate()
    {
        m_FirePosition = m_Roca.position;
        // 주변 적을 감지 //vecter.up 을 해줘야한다..
        m_Targets = Physics.SphereCastAll(m_FirePosition, m_ScanRange, Vector3.up, 0, m_TargetLayer);
        m_NearTarget = GetTargetPos(m_FirePosition);


    }

    // 다른 대상도 사용 할 수 있도록 함수화
    public Transform GetTargetPos(Vector3 myPosition)
    {
        Transform result = null;
        float diff = 80f;

        foreach(RaycastHit target in m_Targets)
        {
            Vector3 targetPosition = target.transform.position;            
            float gapDiff = Vector3.Distance(myPosition, targetPosition);
            //두 위치 사이의 거리를 구하는 식
            //Debug.Log("Target: " + target.transform.name);

            if (gapDiff < diff)
            {
                diff = gapDiff ;
                result = target.transform;
            }

        }

        return result;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(m_FirePosition, m_ScanRange);
    }

}
