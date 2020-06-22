using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth.OnHealthChanged += Health_OnHealthChanged;
        UpdateHealthBar();
    }

    private void Health_OnHealthChanged(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        text.text = playerHealth.GetHealth().ToString();
    }
}
