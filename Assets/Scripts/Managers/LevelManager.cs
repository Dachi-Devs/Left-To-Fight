using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float remainingTime = 5;
    private bool hordeActive = false;

    public event EventHandler OnTimerUpdate;
    public event EventHandler OnHordeActive;

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            OnTimerUpdate?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            if (!hordeActive)
            {
                hordeActive = true;
                OnHordeActive?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
