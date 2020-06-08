using UnityEngine;

public class RotateToMouse : MonoBehaviour, IRotate
{
    public bool allowRotation = false;
    private Vector3 targetPos;

    public void SetRotation(float zRot)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRot));
    }

    public void ToggleRotation()
    {
        allowRotation = !allowRotation;
    }

    public void SetDirection(Vector3 target)
    {
        targetPos = target;
    }

    void Update()
    {
        if (allowRotation)
        {
            targetPos = Input.mousePosition;
            targetPos = Camera.main.ScreenToWorldPoint(targetPos);
            Vector2 rotation = targetPos - transform.position;
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            SetRotation(angle);
        }
    }
}
