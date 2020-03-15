using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private InventoryUI invUI;

    void Awake()
    {
        inventory = new Inventory();
        invUI.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.Gun, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-20, 20), new Item { itemType = Item.ItemType.Wood, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(20, -20), new Item { itemType = Item.ItemType.Medkit, quantity = 1 });
    }
}
