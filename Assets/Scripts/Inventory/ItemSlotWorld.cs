using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotWorld : MonoBehaviour
{
    [SerializeField]
    private ItemSlot itemSlot;

    public void SetItemSlot(ItemSlot itemSlot) => this.itemSlot = itemSlot;

    public ItemSlot GetItemSlot() => itemSlot;
}
