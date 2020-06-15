using UnityEngine;

public class TransferToScene : MonoBehaviour
{
    public IItemContainer transferInv;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetInventoryToTransfer(IItemContainer inv)
    {
        transferInv = inv;
    }

    public void TransferToInventory(IItemContainer inv)
    {
        foreach (ItemSlot itemSlot in transferInv.GetItemList())
        {
            inv.AddItem(itemSlot);
            transferInv.RemoveItem(itemSlot);
        }

        if (transferInv.GetItemList().Capacity < 1)
        {
            Destroy(gameObject);
        }
    }
}
