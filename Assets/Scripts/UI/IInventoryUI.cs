public interface IInventoryUI
{
    void SetInventory(Inventory inventory);

    void Inventory_OnItemListChanged(object sender, System.EventArgs e);

    void UpdateInventoryList();

    void UpdateInvButton();

    void ReverseInventory();

    void SortInventoryAlphabetical();

    void SortInventoryByQuantity();

    void SwapItems(int a, int b);
}
