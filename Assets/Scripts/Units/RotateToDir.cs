using UnityEngine;

public class RotateToDir : MonoBehaviour, IRotate
{
    public bool allowRotation = true;
    private Vector3 targetPos;
    private Transform targetObject;
    public float rotationLimit;

    public Quaternion targetAngle;

    public void SetRotation(float zRot)
    {
        targetAngle = Quaternion.Euler(new Vector3(0, 0, zRot));
        if (Quaternion.Angle(transform.rotation, targetAngle) > rotationLimit)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, Time.deltaTime * 15f);
        }
    }

    public void ToggleRotation()
    {
        allowRotation = !allowRotation;
    }

    public void SetDirection(Vector3 target)
    {
        targetPos = target;
    }

    public void SetTargetObject(Transform target)
    {
        targetObject = target;
    }

    void Update()
    {
        if (allowRotation)
        {
            if (targetObject != null)
            {
                targetPos = targetObject.position;
            }
            Vector2 rotation = targetPos - transform.position;
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90;
            SetRotation(angle);
        }
    }
}
