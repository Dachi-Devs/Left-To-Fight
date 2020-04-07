using System;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    [Range(1, 99)]
    public int quantity;

    public ItemSlot(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void AddToQuantity(int amountToAdd)
    {
        quantity += amountToAdd;
    }
}
