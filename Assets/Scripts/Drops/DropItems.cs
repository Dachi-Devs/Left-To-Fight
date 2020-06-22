using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public DropTableSO dropTable;

    public void Drop()
    {
        ItemSlot itemFromTable = dropTable.GetItem();
        DropItem(itemFromTable);
    }

    private void DropItem(ItemSlot item)
    {
        GameObject drop = Instantiate(DropManager.Instance.dropPrefab, transform.position, Quaternion.identity);
        drop.GetComponent<ItemSlotWorld>().SetItemSlot(item);
        drop.name = item.item.name;
    }
}
