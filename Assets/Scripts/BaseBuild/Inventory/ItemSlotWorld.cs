using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotWorld : MonoBehaviour
{
    [SerializeField]
    private ItemSlot itemSlot;

    [SerializeField]
    private string humanTag;

    private void Start()
    {
        SetItemSlot(itemSlot);
    }

    public void SetItemSlot(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        GetComponent<SpriteRenderer>().sprite = this.itemSlot.item.sprite;
    }

    public ItemSlot GetItemSlot() => itemSlot;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == humanTag)
        {
            collision.gameObject.GetComponent<PlayerInventory>().inventory.AddItem(itemSlot);
            Destroy(gameObject);
        }
    }
}
