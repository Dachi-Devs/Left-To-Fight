using Boo.Lang;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public IItemContainer sceneInventory;

    [SerializeField]
    private Inventory transferInventory;

    void Start()
    {
        sceneInventory = CheckForInventoryType();
        TransferToInventory(sceneInventory);
    }

    private IItemContainer CheckForInventoryType()
    {
        IItemContainer foundInv;

        BaseInventory baseInv = FindObjectOfType<BaseInventory>();
        PlayerInventory playerInv = FindObjectOfType<PlayerInventory>();
        if (baseInv != null)
            foundInv = baseInv.inventory;
        else if (playerInv != null)
        {
            foundInv = playerInv.inventory;
        }
        else
        {
            Debug.LogError("NO INVENTORY FOUND IN SCENE");
            return null;
        }
        return foundInv;
    }

    public void TransitionToScene(string sceneName)
    {
        List<ItemSlot> transferredItems = new List<ItemSlot>();
        foreach (ItemSlot itemSlot in sceneInventory.GetItemList())
        {
            transferInventory.AddItem(itemSlot);
            transferredItems.Add(itemSlot);
        }

        foreach (ItemSlot itemSlot in transferredItems)
        {
            sceneInventory.RemoveItem(itemSlot);
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


    public void TransferToInventory(IItemContainer inv)
    {
        if (transferInventory.GetCurrentOccupiedSlots() > 0)
        {
            foreach (ItemSlot itemSlot in transferInventory.GetItemList())
            {
                inv.AddItem(itemSlot);
            }
            transferInventory.ClearInventory();
        }
    }
}
