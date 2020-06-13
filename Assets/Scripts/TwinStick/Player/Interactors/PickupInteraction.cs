using UnityEngine;

public class PickupInteraction : Interaction
{
    private ItemSlotWorld itemSlotWorld;

    private void Start()
    {
        itemSlotWorld = transform.root.GetComponent<ItemSlotWorld>();
        spr = transform.root.GetComponent<SpriteRenderer>();
    }

    public override void InteractWithObject(GameObject interactor) => Pickup(interactor);

    void Pickup(GameObject interactor)
    {
        IItemContainer interactorContainer = interactor.GetComponent<IItemContainer>();

        if (interactorContainer == null) { return; }

        if (interactorContainer.AddItem(itemSlotWorld.GetItemSlot())) { GetComponentInParent<DestroySelf>().Destroy() ; }
    }
}
