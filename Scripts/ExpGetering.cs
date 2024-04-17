using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGetering : MonoBehaviour
{
    public void SetGeteringBool()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.GetComponent<EXP>().DoGetering();
        }
    }
}
