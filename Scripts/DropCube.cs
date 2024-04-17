using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCube : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 9: //7번은 몬스터        

                break;
        }
    }

    private void OnParticleCollision(GameObject uc_Target)
    {
        Debug.Log("메테오와 몬스터 충돌");
        if (uc_Target != null)
        {
            switch (uc_Target.layer)
            {
                case 9: // 9번은 몬스터

                    Enemy[] m = uc_Target.GetComponents<Enemy>();
                    foreach (Enemy mm in m)
                    {
                        Debug.Log(mm);
                        mm.DoMeteorDamege();
                    }

                    break;
            }
        }
    }

}
