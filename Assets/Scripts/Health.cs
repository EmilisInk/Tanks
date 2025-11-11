using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            var player = GetComponent<Player>();
            if(player.isPlayer1)
            {
                Score.Instance.setScore(p2: 1);
            }
            else
            {
                Score.Instance.setScore(p1:1);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        currentHealth -= damage;

        healthBar.localScale = new Vector3((float)currentHealth / maxHealth, healthBar.localScale.y, healthBar.localScale.z);
    }


}
