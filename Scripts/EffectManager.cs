using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject[] chosenEffect;
    public float loopTimeLimit = 2.0f;
    public enum m_EPlayEffectKind {GETITEM, GETITEM2, GETITEM3, LVUP };

    public GameObject[] m_UGO_DamegedEffect;


    public void PlayEffect(int e_Kind)
    {
        switch (e_Kind)
        {    
            case 0:
                StartCoroutine(EffectStart(m_EPlayEffectKind.GETITEM));
                return;
            case 1:
                StartCoroutine(EffectStart(m_EPlayEffectKind.GETITEM2));
                return;
            case 2:
                StartCoroutine(EffectStart(m_EPlayEffectKind.GETITEM3));
                return;
            case 3:
                StartCoroutine(EffectStart(m_EPlayEffectKind.LVUP));
                return;
        }
    }

    IEnumerator EffectStart(m_EPlayEffectKind e_Kind)
    {
        
        //GameObject effectPlayer = (GameObject)Instantiate(chosenEffect[(int)e_Kind]);
        //effectPlayer.transform.position = transform.position;
        
        GameObject effectPlayer = chosenEffect[(int)e_Kind];
        ParticleSystem a = effectPlayer.GetComponent<ParticleSystem>();
        a.Play();
        Debug.Log(a);
        
        yield return new WaitForSeconds(loopTimeLimit);
        a.Stop();
    }

}
