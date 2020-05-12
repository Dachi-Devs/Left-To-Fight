using System.Collections.Generic;

public interface IItemContainer
{
    bool ContainsItem(ItemSlot item);
    int ItemCount(ItemSlot item);
    bool RemoveItem(ItemSlot item);
    bool AddItem(ItemSlot item);
    bool IsFull();
    bool RemoveQuantity(ItemSlot item, int amountToRemove);

    int GetInventorySize();
    List<ItemSlot> GetItemList();
}
