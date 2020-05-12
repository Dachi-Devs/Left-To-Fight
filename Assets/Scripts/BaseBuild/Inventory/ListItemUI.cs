using UnityEngine;
using UnityEngine.UI;

public class ListItemUI : MonoBehaviour
{
    public Image sprite;
    public Text itemNameText;
    public Text quantityText;
    
    public void UpdateItem(ItemSlot item)
    {
        sprite.sprite = item.item.sprite;
        itemNameText.text = item.item.itemName;
        if (item.quantity > 1)
        {
            quantityText.text = item.quantity.ToString();
        }
        else
        {
            quantityText.text = "";
        }
    }
}
