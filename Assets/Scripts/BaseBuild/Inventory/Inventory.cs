using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Items/New Inventory")]
[Serializable]
public class Inventory : ScriptableObject, IItemContainer
{
    public event EventHandler OnItemListChanged;

    [SerializeField]
    private List<ItemSlot> itemSlots;
    private int inventorySize = 15;
    private int maxStack = 99;
    public Inventory()
    {
        itemSlots = new List<ItemSlot>();
    }

    public bool AddItem(ItemSlot item)
    {
        Debug.Log(item.item + " " + item.quantity);
        ItemSlot temp = NewItem(item.item, item.quantity);
        if (IsFull())
        {
            Debug.Log("INV FULL");
            return false;
        }
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (temp.item.itemName == itemSlot.item.itemName)
            {
                if (temp.item.isStackable)
                {
                    if (itemSlot.quantity < maxStack)
                    {
                        if (itemSlot.quantity + temp.quantity > maxStack)
                        {
                            int stackDifference = itemSlot.quantity + temp.quantity - maxStack;
                            int amountToAdd = maxStack - itemSlot.quantity;
                            if (amountToAdd > 0)
                            {
                                itemSlot.AddToQuantity(amountToAdd);
                            }
                            itemSlots.Add((NewItem(temp.item, stackDifference)));
                        }
                        else
                        {
                            itemSlot.AddToQuantity(temp.quantity);
                        }
                        OnItemListChanged?.Invoke(this, EventArgs.Empty);
                        return true;
                    }
                }
            }
        }

        itemSlots.Add(temp);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
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
        int totalCount = 0;
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                totalCount += itemSlot.quantity;
            }
        }
        return totalCount;
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
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        return false;
    }

    public bool RemoveQuantity(ItemSlot item, int amountToRemove)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (item.item.itemName == itemSlot.item.itemName)
            {
                itemSlot.AddToQuantity(-amountToRemove);

                if (ItemCount(itemSlot) == 0)
                {
                    RemoveItem(itemSlot);
                }
                return true;
            }
        }
        return false;
    }

    private ItemSlot NewItem(Item item, int quant)
    {
        ItemSlot tempItemSlot = new ItemSlot(item, quant);
        return tempItemSlot;
    }

    public List<ItemSlot> GetItemList()
    {
        return itemSlots;
    }

    public int GetInventorySize()
    {
        return inventorySize;
    }

    public int GetCurrentOccupiedSlots()
    {
        int count = 0;
        foreach (ItemSlot item in itemSlots)
            count++;

        return count;
    }

    public bool ClearInventory()
    {
        foreach(ItemSlot itemSlot in itemSlots)
        {
            itemSlots = new List<ItemSlot>();
        }
        return true;
    }
}
