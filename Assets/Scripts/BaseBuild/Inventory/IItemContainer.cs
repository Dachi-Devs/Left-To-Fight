using System.Collections.Generic;

public interface IItemContainer
{
    bool ContainsItem(ItemSlot item);
    int ItemCount(ItemSlot item);
    bool RemoveItem(ItemSlot item);
    bool AddItem(ItemSlot item);
    bool IsFull();
    bool RemoveQuantity(ItemSlot item, int amountToRemove);
    void SetInventorySize(int size);
    void AddToInventorySize(int sizeToAdd);
    int GetInventorySize();
    int GetCurrentOccupiedSlots();
    bool ClearInventory();
    List<ItemSlot> GetItemList();
}
