using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float remainingTime = 5;

    private void Update()
    {
        if (remainingTime < 0)
            remainingTime -= Time.deltaTime;
    }
}
