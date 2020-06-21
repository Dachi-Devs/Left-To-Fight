using System.Collections.Generic;
using UnityEngine;

public class BaseInventory : MonoBehaviour, IItemContainer
{    
    public Inventory inventory;

    void Start()
    {
        //FindObjectOfType<InventoryUI>().SetInventory(inventory);
        //FindObjectOfType<CraftingUI>().SetInventory(inventory);
        FindObjectOfType<ListInventoryUI>().SetInventory(inventory);
    }

    public bool AddItem(ItemSlot item) => inventory.AddItem(item);
    public bool ContainsItem(ItemSlot item) => inventory.ContainsItem(item);
    public int GetCurrentOccupiedSlots() => inventory.GetCurrentOccupiedSlots();
    public void SetInventorySize(int size) => inventory.SetInventorySize(size);
    public void AddToInventorySize(int sizeToAdd) => inventory.AddToInventorySize(sizeToAdd);
    public int GetInventorySize() => inventory.GetInventorySize();
    public List<ItemSlot> GetItemList() => inventory.GetItemList();
    public bool IsFull() => inventory.IsFull();
    public int ItemCount(ItemSlot item) => inventory.ItemCount(item);
    public bool RemoveItem(ItemSlot item) => inventory.RemoveItem(item);
    public bool RemoveQuantity(ItemSlot item, int amountToRemove) => inventory.RemoveQuantity(item, amountToRemove);
    public bool ClearInventory() => inventory.ClearInventory();
}