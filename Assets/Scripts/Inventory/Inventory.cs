﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Wood, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Gun, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Medkit, quantity = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
