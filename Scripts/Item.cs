using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public enum ITEM_KIND { POTION, GATHERING_EXP, BOOM}
    public ITEM_KIND item_kind;
    public bool m_InvenIsEmpty;
    public GameObject m_ExpGeter;
    // 스테틱 선언 - 이게임의 EXP 게임오브젝트
    

    private void Awake()
    {
        
    }

    public Item(ITEM_KIND itemKind)
    {
        item_kind = itemKind;
        m_InvenIsEmpty = false;
        m_ExpGeter = GameObject.Find("EXP");
    }

    public bool UseItem(ITEM_KIND tagetItem)
    {
        switch (tagetItem)
        {
            case ITEM_KIND.POTION:
                GameManager.gameManager.player.m_PlayerHP = GameManager.gameManager.m_PlayerHp;
                break;

            case ITEM_KIND.GATHERING_EXP:
                ExpGetering exp = m_ExpGeter.GetComponent<ExpGetering>();
                exp.SetGeteringBool();                
                break;

            case ITEM_KIND.BOOM:

                break;
        }

        return true;
    }
    
    private void OnTriggerStay(Collider collision)
    {
        
        switch (collision.gameObject.layer)
        {
            case 8: //8번은 플레이어


                m_InvenIsEmpty = GameManager.gameManager.CheckInventory();
                if (!m_InvenIsEmpty)
                    return;
                GameManager.gameManager.SetIventory(item_kind);
                Debug.Log(this);
                Destroy(this.gameObject);
                //객체가 삭제되면 해당 메모리를 참고할 수 없음
                break;
        }
    }


}
