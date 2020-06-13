using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    public bool unlocked;

    public override void InteractWithObject(GameObject interactor)
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        Debug.Log("LEAVE LEVEL");
    }
}
