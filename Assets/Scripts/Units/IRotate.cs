using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotate
{
    void SetRotation(float zRot);
    void SetDirection(Vector3 target);
    void ToggleRotation();
}