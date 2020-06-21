using UnityEngine;
using UnityEngine.UI;

public class GridItemUI : MonoBehaviour
{
    public Image sprite;
    public Text quantityText;
    
    public void UpdateItem(ItemSlot item)
    {
        sprite.sprite = item.item.sprite;
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
