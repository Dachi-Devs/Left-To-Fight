using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotWorld : MonoBehaviour
{
    [SerializeField]
    private ItemSlot itemDropped;

    [SerializeField]
    private string humanTag;

    private void Start()
    {
        SetItemSlot(itemDropped);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(EnableHitbox());
    }

    private IEnumerator EnableHitbox()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Collider2D>().enabled = true;
    }

    public void SetItemSlot(ItemSlot itemSlot)
    {
        itemDropped = new ItemSlot(itemSlot.item, itemSlot.quantity);
        GetComponent<SpriteRenderer>().sprite = itemDropped.item.sprite;
        itemDropped.quantity = Random.Range(-5, 5);
        if (itemDropped.quantity < 1)
        {
            itemDropped.quantity = 1;
        }
        if (!itemDropped.item.isStackable)
        {
            itemDropped.quantity = 1;
        }
    }

    public ItemSlot GetItemSlot() => itemDropped;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == humanTag)
        {
            collision.gameObject.GetComponent<PlayerInventory>().inventory.AddItem(itemDropped);
            Destroy(gameObject);
        }
    }
}
