using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage(float damageToTake)
    {
        currentHealth -= damageToTake;
    }
}
