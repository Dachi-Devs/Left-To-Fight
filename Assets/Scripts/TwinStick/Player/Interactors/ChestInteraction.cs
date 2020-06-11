using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : Interaction
{
    public override void InteractWithObject(GameObject interactor)
    {
        OpenChest();
    }

    void OpenChest()
    {
        Debug.Log("Open Chest");
    }
}
