using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    public void Damage(float damageToTake)
    {
        currentHealth -= damageToTake;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
