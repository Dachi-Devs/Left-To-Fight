using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory : IItemContainer
{
    [SerializeField]
    private List<ItemSlot> itemSlots;
    private int inventorySize = 20;
    public Inventory()
    {
        itemSlots = new List<ItemSlot>();
    }

    public int OnItemListChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool AddItem(ItemSlot item)
    {
        ItemSlot temp = NewItem(item);
        if (IsFull())
        {
            return false;
        }
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (temp.item.itemName == itemSlot.item.itemName)
            {
                itemSlot.AddToQuantity(temp.quantity);
                return true;
            }
        }
        itemSlots.Add(temp);
        return true;
    }

    public bool ContainsItem(ItemSlot item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        if (itemSlots.Count >= inventorySize)
        {
            return true;
        }
        return false;
    }

    public int ItemCount(ItemSlot item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                return itemSlot.quantity;
            }
        }
        return 0;
    }

    public bool RemoveItem(ItemSlot item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                itemSlots.Remove(itemSlot);
                return true;
            }
        }
        return false;
    }

    public bool AddToQuantity(ItemSlot item, int amountToAdd)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                itemSlot.AddToQuantity(amountToAdd);
                if (ItemCount(itemSlot) == 0)
                {
                    RemoveItem(itemSlot);
                }
                return true;
            }
        }
        return false;
    }

    private ItemSlot NewItem(ItemSlot itemSlot)
    {
        ItemSlot tempItemSlot = new ItemSlot(itemSlot.item, itemSlot.quantity);
        return tempItemSlot;
    }
}
