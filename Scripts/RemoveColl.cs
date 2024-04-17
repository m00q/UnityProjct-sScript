using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveColl : MonoBehaviour
{
    private List<Transform> childObjectsList = new List<Transform>();

    private void Start()
    {
        CollectChildObjectsRecursive(transform);

        // 리스트에 있는 자식 오브젝트의 컬라이더 제거
        RemoveColliders();
    }

    private void CollectChildObjectsRecursive(Transform parent)
    {
        // 현재 부모의 자식들을 리스트에 추가
        foreach (Transform child in parent)
        {
            childObjectsList.Add(child);

            // 자식 오브젝트의 하위 자식들도 검사하기 위해 재귀 호출
            CollectChildObjectsRecursive(child);
        }
    }

    private void RemoveColliders()
    {
        foreach (Transform child in childObjectsList)
        {
            // 자식 오브젝트가 가진 모든 종류의 컬라이더를 검색하고 제거
            Collider[] colliders = child.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                Destroy(collider);
            }
        }
    }
}
