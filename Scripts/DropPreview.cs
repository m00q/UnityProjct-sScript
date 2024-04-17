using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DropPreview : MonoBehaviour
{
    public Transform dropStartPosition; // 박스가 떨어질 시작 위치
    public LayerMask groundLayer; // 땅을 나타내는 레이어

    private LineRenderer lineRenderer;

    void Start()
    {
        // LineRenderer 컴포넌트 추가
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 시작점과 끝점으로 2개의 포인트 사용

        // 라인 렌더러의 머티리얼 설정
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        // 라인 렌더러의 너비 설정
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
    }

    void Update()
    {
        dropStartPosition = this.transform;
        // 박스가 떨어질 위치에서 바닥까지 선을 그림
        DrawDropPreview();
    }

    void DrawDropPreview()
    {
        RaycastHit hit;
        Vector3 dropEndPosition = dropStartPosition.position - new Vector3(0, 10, 0); // 떨어질 위치에서 아래로 충분히 긴 선을 그림

        // Raycast를 사용하여 땅과의 충돌을 감지
        if (Physics.Raycast(dropStartPosition.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            dropEndPosition = hit.point; // 충돌 지점까지 선을 그림
        }

        // 라인 렌더러의 시작점과 끝점 설정
        lineRenderer.SetPosition(0, dropStartPosition.position);
        lineRenderer.SetPosition(1, dropEndPosition);
    }
}