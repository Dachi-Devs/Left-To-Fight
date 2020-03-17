using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public Recipe selectedRecipe;
    public Item testItem;
    public IItemContainer inventory;
    public Image[] recipeImages;
    public Image outputImage;

    void Start()
    {
        UpdateCraftingWindow();
    }

    public void CraftButton()
    {
        selectedRecipe.Craft(inventory);
    }

    public void SetInventory(IItemContainer inventory)
    {
        this.inventory = inventory;
    }

    public void AddToInventory()
    {
        ItemSlot tempItemSlot = new ItemSlot(testItem, 2);
        inventory.AddItem(tempItemSlot);
    }

    public void UpdateCraftingWindow()
    {
        List<ItemSlot> mats = selectedRecipe.materials;
        for (int i = 0; i < mats.Count; i++)
        {
            recipeImages[i].sprite = mats[i].item.sprite;
            recipeImages[i].GetComponentInChildren<Text>().text = mats[i].quantity.ToString();
        }

        outputImage.sprite = selectedRecipe.output.item.sprite;
    }
}
