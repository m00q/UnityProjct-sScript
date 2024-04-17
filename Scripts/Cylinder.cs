using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{

    public float m_AngularVelocity;
    public float m_ForwardSpeed;
    Vector3 forwardDirection;

    void OnEnable()
    {
        float yRotation = transform.eulerAngles.y;
        forwardDirection = Quaternion.Euler(0f, yRotation, 0f) * Vector3.forward;
    }

    void OnDisable()
    {
       
    }

    void FixedUpdate()
    {
        DoRolling();
        DoMove();
    }


    void DoRolling()
    {
        Quaternion rolling = Quaternion.Euler(0f, -m_AngularVelocity * Time.deltaTime, 0f);
        Transform mawaruMono = this.GetComponent<Transform>();
        mawaruMono.rotation *= rolling;
    }

    void DoMove()
    {
        

        Transform mawaruMono = this.GetComponent<Transform>();
        
        mawaruMono.Translate(forwardDirection * m_ForwardSpeed * Time.deltaTime, Space.World);
    }
}

