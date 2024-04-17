using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public float radius = 50f; // 원형 범위의 반지름
    //public LayerMask objectLayer; // 레이캐스트가 충돌을 검출할 레이어
    private Transform closestEnemyPosition; // 가장 가까운 적의 위치를 저장할 변수


    void Update()
    {
        FindClosestEnemyInRadius();
    }


    void FindClosestEnemyInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        if (colliders.Length > 0)
        {
            Collider closestCollider = null;
            float closestDistance = float.MaxValue;

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);

                    if (distance < closestDistance)
                    {
                        closestCollider = collider;
                        closestDistance = distance;
                    }
                }
            }

            // 가장 가까운 적의 위치를 저장
            closestEnemyPosition = closestCollider.transform;

            // closestCollider가 가장 가까운 오브젝트입니다.
            Debug.Log("가장 가까운 오브젝트: " + closestCollider.gameObject.name);
        }
        else
        {
            // 원형 범위 내에 오브젝트가 없음
            Debug.Log("원형 범위 내에 오브젝트가 없습니다.");
        }
    }

    private void OnDrawGizmos()
    {
        
    Vector3 vPos = this.transform.position;
    Gizmos.color = Color.yellow;
            

    //Vector3 vWayPointPos = waypoints[m_CurrentWaypointIndex].position;
    //Gizmos.color = Color.red;
    

            
    //Gizmos.color = Color.white;
    Gizmos.DrawWireSphere(vPos, radius);
            
    }
}
