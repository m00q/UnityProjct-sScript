using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPointColor : MonoBehaviour
{
    public float radius = 0.5f;
    public int segments = 32;
    public Color sphereColor = Color.magenta;

    void OnDrawGizmos()
    {
        DrawFilledSphere();
    }

    void DrawFilledSphere()
    {
        Gizmos.color = sphereColor;

        float angle = 0f;
        float angleIncrement = 360f / segments;

        Vector3 center = transform.position;

        for (int i = 0; i <= segments; i++)
        {
            float x = center.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y = center.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            float z = center.z + radius * Mathf.Sin(Mathf.Deg2Rad * angle); // 추가된 부분

            Vector3 currentPoint = new Vector3(x, y, z);

            Gizmos.DrawLine(center, currentPoint);
            Gizmos.DrawSphere(currentPoint, 0.02f); // DrawSphere를 사용하여 구를 그립니다.

            angle += angleIncrement;
        }
    }
}

