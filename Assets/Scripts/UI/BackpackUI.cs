using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : MonoBehaviour, IInventoryUI
{
    [SerializeField]
    private Transform gridPanel;
    [SerializeField]
    private GameObject gridItem;
    [SerializeField]
    private GameObject emptyGridItem;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private List<ItemSlot> itemList;

    void Start()
    {
        itemList = new List<ItemSlot>();
        if (inventory == null)
        {
            Debug.LogError("UI INVENTORY NULL, PLS FIX");
        }
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        UpdateInventoryList();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        UpdateInventoryList();
    }

    public void UpdateInventoryList()
    {
        itemList = inventory.GetItemList();
        foreach (Transform child in gridPanel)
        {
            Destroy(child.gameObject);
        }

        if (itemList.Count > 0)
        {
            foreach (ItemSlot item in itemList)
            {
                GameObject i = Instantiate(gridItem, gridPanel);
                i.GetComponent<GridItemUI>().UpdateItem(item);
            }
        }

        if (itemList.Count < inventory.GetInventorySize())
        {
            for (int i = itemList.Count; i < inventory.GetInventorySize(); i++)
            {
                GameObject empty = Instantiate(emptyGridItem, gridPanel);
            }
        }
    }

    public void UpdateInvButton()
    {
        UpdateInventoryList();
    }

    public void ReverseInventory()
    {
        itemList.Reverse();
        UpdateInventoryList();
    }

    public void SortInventoryAlphabetical()
    {
        bool swap;
        for (int i = 0; i < itemList.Count - 1; i++)
        {
            swap = false;
            for (int j = 0; j < itemList.Count - 1; j++)
            {
                if (itemList[j].quantity > itemList[j + 1].quantity)
                {
                    SwapItems(j, j + 1);
                    Debug.Log("Swaps found");
                    swap = true;
                }
            }
            if (!swap)
            {
                Debug.Log("No swaps made, list sorted");
                break;
            }
        }
        UpdateInventoryList();
    }

    public void SortInventoryByQuantity()
    {
        bool swap;
        for (int i = 0; i < itemList.Count - 1; i++)
        {
            swap = false;
            for (int j = 0; j < itemList.Count - 1; j++)
            {
                if (itemList[j].quantity > itemList[j + 1].quantity)
                {
                    SwapItems(j, j + 1);
                    Debug.Log("Swaps found");
                    swap = true;
                }
            }
            if (!swap)
            {
                Debug.Log("No swaps made, list sorted");
                break;
            }
        }
        UpdateInventoryList();
    }

    public void SwapItems(int a, int b)
    {
        ItemSlot temp = itemList[a];
        itemList[a] = itemList[b];
        itemList[b] = temp;
    }
}
