using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform healthBar;
    public int maxHealth;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void Damage(int damage)
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print("TODO: DIE");
        }

        currentHealth -= damage;

        healthBar.localScale = new Vector3((float)currentHealth / maxHealth, healthBar.localScale.y, healthBar.localScale.z);
    }


}
