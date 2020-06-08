using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public enum Quality
    {
        crafting,
        common,
        uncommon,
        rare,
        ultra,
        legendary
    }

    public string itemName;
    public bool isStackable;
    public Sprite sprite;
    public Quality quality;
}
