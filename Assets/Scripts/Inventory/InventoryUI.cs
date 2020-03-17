using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
}
