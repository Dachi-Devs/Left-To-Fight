using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
        return;
    }

    public void DestroyParent()
    {
        Destroy(gameObject.transform.root.gameObject);
        return;
    }
}
