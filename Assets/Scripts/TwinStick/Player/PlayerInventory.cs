using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IItemContainer
{
    public Inventory inventory;

    public bool AddItem(ItemSlot item) => inventory.AddItem(item);
    public bool ContainsItem(ItemSlot item) => inventory.ContainsItem(item);
    public int GetCurrentOccupiedSlots() => inventory.GetCurrentOccupiedSlots();
    public int GetInventorySize() => inventory.GetInventorySize();
    public List<ItemSlot> GetItemList() => inventory.GetItemList();
    public bool IsFull() => inventory.IsFull();
    public int ItemCount(ItemSlot item) => inventory.ItemCount(item);
    public bool RemoveItem(ItemSlot item) => inventory.RemoveItem(item);
    public bool RemoveQuantity(ItemSlot item, int amountToRemove) => inventory.RemoveQuantity(item, amountToRemove);
    public bool ClearInventory() => inventory.ClearInventory();
}
