using UnityEngine;

public class RotateToMouse : MonoBehaviour, IRotate
{
    public bool allowRotation = false;
    
    public void SetRotation(float zRot)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot));
    }

    public void ToggleRotation()
    {
        allowRotation = !allowRotation;
    }

    void Update()
    {
        if (allowRotation)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 rotation = mousePos - transform.position;
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            SetRotation(angle);
        }
    }
}
