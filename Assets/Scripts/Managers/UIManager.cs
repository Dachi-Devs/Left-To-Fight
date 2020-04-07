using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject ListInventory;

    public void ToggleListInventory()
    {
        ListInventory.SetActive(!ListInventory.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleListInventory();
        }
    }
}
