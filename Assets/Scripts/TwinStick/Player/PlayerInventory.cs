using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        inventory = new Inventory();
    }
}
