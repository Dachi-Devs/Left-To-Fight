using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Wood,
        Metal,
        Gun,
        Medkit,
    }

    public ItemType itemType;    
    public int quantity;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Wood:     return ItemAssets.Instance.woodSprite;
            case ItemType.Metal:    return ItemAssets.Instance.metalSprite;
            case ItemType.Gun:      return ItemAssets.Instance.gunSprite;
            case ItemType.Medkit:   return ItemAssets.Instance.medkitSprite;
        }
    }
}
