using UnityEngine;

[CreateAssetMenu(fileName = "New Drop Table", menuName = "Items/New Drop Table")]
public class DropTableSO : ScriptableObject
{
    public ItemSlot[] tableContents;
    private int totalItemLength;

    public ItemSlot GetItem()
    {
        GetTableLength();

        int itemIndex = Random.Range(1, totalItemLength);
        Debug.Log(itemIndex);

        ItemSlot returnedItem = tableContents[0];
        foreach(ItemSlot i in tableContents)
        {
            int slotTickets = DropManager.Instance.qualityValues[i.item.quality.ToString()];
            Debug.Log(slotTickets);
            itemIndex -= slotTickets;
            if (itemIndex <= 0)
            {
                returnedItem = i;
                return returnedItem;
            }
        }
        return returnedItem;
    }

    private void GetTableLength()
    {
        totalItemLength = 0;
        foreach (ItemSlot i in tableContents)
        {
            int count = DropManager.Instance.qualityValues[i.item.quality.ToString()];
            totalItemLength += count;
        }
    }
}
