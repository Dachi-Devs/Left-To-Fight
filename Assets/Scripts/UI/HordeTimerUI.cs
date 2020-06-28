using System;
using UnityEngine;
using UnityEngine.UI;

public class HordeTimerUI : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<LevelManager>().OnTimerUpdate += LevelManager_OnTimerUpdate;
        FindObjectOfType<LevelManager>().OnHordeActive += LevelManager_OnHordeActive;
    }

    private void LevelManager_OnHordeActive(object sender, EventArgs e)
    {
        timerText.text = SecondsToTimer(0);
    }

    private void LevelManager_OnTimerUpdate(object sender, System.EventArgs e)
    {
        timerText.text = SecondsToTimer(LevelManager.remainingTime);
    }

    private string SecondsToTimer(float secondsF)
    {
        string minutes = Mathf.Floor(secondsF / 60).ToString("00");
        string seconds = Mathf.Floor(secondsF % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
