using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIventory : MonoBehaviour
{
    public List<Item> listItems = new List<Item>();
    public bool m_IsInventoryEmpty;

    public void AddItemToInventory(Item.ITEM_KIND item)
    {
        Item itemOne = new Item(item);
        listItems.Add(itemOne);
        Debug.Log(itemOne.item_kind);
        Debug.Log(itemOne.m_ExpGeter);
        Debug.Log(itemOne.m_InvenIsEmpty);
    }

    public void RemoveItemToIventory(Item item)
    {
        listItems.Remove(item);
    }

    public bool CheckInventory()
    {
        if (listItems.Count == 1)
            m_IsInventoryEmpty = false;
        else
            m_IsInventoryEmpty = true;
        return m_IsInventoryEmpty;
    }

}
