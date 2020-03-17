public interface IItemContainer
{
    int OnItemListChanged { get; set; }

    bool ContainsItem(ItemSlot item);
    int ItemCount(ItemSlot item);
    bool RemoveItem(ItemSlot item);
    bool AddItem(ItemSlot item);
    bool IsFull();
    bool AddToQuantity(ItemSlot item, int amountToReduce);
}
