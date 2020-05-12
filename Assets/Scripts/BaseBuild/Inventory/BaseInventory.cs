using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        inventory = new Inventory();
        //FindObjectOfType<InventoryUI>().SetInventory(inventory);
        //FindObjectOfType<CraftingUI>().SetInventory(inventory);
        FindObjectOfType<ListInventoryUI>().SetInventory(inventory);
    }
}
