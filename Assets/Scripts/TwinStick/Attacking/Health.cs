using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private ArmourSO armour;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageToTake, float armourPen)
    {
        float finalDamage;
        if (armour != null)
        {
            if (armourPen > armour.armourResist)
            {
                finalDamage = damageToTake;
            }
            else
            {
                finalDamage = damageToTake * armourPen / armour.armourResist;
            }
        }
        else
            finalDamage = damageToTake;
        currentHealth -= finalDamage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            DropItems drop = GetComponent<DropItems>();
            if (drop != null)
                drop.Drop();
            Destroy(gameObject);
        }
    }

    public void Heal(float healthToHeal)
    {
        if (currentHealth + healthToHeal > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += healthToHeal;
    }
}
