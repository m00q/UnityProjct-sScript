using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class view : MonoBehaviour
{
    public GameObject player;
    public Vector3 xyz;
    public Vector3 r_Xyz;

    void FixedUpdate()
    {
        transform.position = player.transform.position + xyz;

        transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(r_Xyz);
    }
    

    void OnDrawGizmosSelected()
    {
        // 현재 객체의 회전을 변경하기 위한 핸들 그리기
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.blue;

        // 회전된 기즈모 그리기
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 1));
    }

}
