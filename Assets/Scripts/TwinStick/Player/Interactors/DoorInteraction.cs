using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    public bool unlocked;
    public string sceneToLoad;

    public override void InteractWithObject(GameObject interactor)
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        FindObjectOfType<SceneTransitionManager>().TransitionToScene(sceneToLoad);
    }
}
