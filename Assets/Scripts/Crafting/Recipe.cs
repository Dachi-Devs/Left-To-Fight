using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<ItemSlot> materials;
    public ItemSlot output;

    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach (ItemSlot item in materials)
        {
            if (itemContainer.ItemCount(item) < item.quantity)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer)
    {
        if (!itemContainer.IsFull())
        {
            if (CanCraft(itemContainer))
            {
                foreach (ItemSlot item in materials)
                {
                    itemContainer.AddToQuantity(item, -item.quantity);
                }
                itemContainer.AddItem(output);
            }
        }
    }
}
