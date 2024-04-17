using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIcon : MonoBehaviour
{
    Transform icon1;
    Transform icon2;

    public void Start()
    {
        icon1 = transform.Find("Icon1");
        icon2 = transform.Find("Icon2");
    }

    public void ClearIcon()
    {
        icon1.gameObject.SetActive(false);
        icon2.gameObject.SetActive(false);
    }

    public void SetIcon1()
    {
        icon1.gameObject.SetActive(true);
    }
    public void SetIcon2()
    {
        icon2.gameObject.SetActive(true);
    }


}
