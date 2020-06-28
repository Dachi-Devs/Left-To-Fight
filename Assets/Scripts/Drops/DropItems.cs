using UnityEngine;

public class DropItems : MonoBehaviour
{
    private DropTableSO dropTable;

    public void Drop()
    {
        ItemSlot itemFromTable = dropTable.GetItem();
        if (itemFromTable != null)
            DropItem(itemFromTable);
    }

    public void SetDropTable(DropTableSO drop)
    {
        dropTable = drop;
    }

    private void DropItem(ItemSlot item)
    {
        GameObject drop = Instantiate(DropManager.Instance.dropPrefab, transform.position, Quaternion.identity);
        drop.GetComponent<ItemSlotWorld>().SetItemSlot(item);
        drop.name = item.item.name;
    }
}
