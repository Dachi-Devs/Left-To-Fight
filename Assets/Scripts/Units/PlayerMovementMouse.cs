using UnityEngine;
using CodeMonkey.Utils;

public class PlayerMovementMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<IMovePos>().SetMovePosition(UtilsClass.GetMouseWorldPosition());
        }
    }
}
