using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
        public float rotationSpeed = 5220f;  // 각 탄환의 회전 속도
        private Vector3 currentRotationDirection;

        public float m_SkillDamage;
        public int m_SkillLv;
        public int m_SkillPiercing;
        public int m_SkillPiercingLimit;

    private void Awake()
    {
        currentRotationDirection = Random.onUnitSphere;
    }

    void FixedUpdate()
        {
            
            RotateObjectByDirection();
        }

        void RotateObjectByDirection()
        {
            // 랜덤한 회전 방향으로 회전
            transform.Rotate(currentRotationDirection * rotationSpeed * Time.deltaTime);
        }
}

