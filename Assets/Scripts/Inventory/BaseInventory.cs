using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    public Inventory inventory;
    private InventoryUI invUI;
    private CraftingUI craftUI;

    void Awake()
    {
        inventory = new Inventory();
        invUI = FindObjectOfType<InventoryUI>();
        invUI.SetInventory(inventory);
        craftUI = FindObjectOfType<CraftingUI>();
        craftUI.SetInventory(inventory);
    }
}
