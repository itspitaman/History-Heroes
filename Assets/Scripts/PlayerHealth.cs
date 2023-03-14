using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int tutorialStartingHealth = 50;

    public HealthBar healthBar;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = tutorialStartingHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().WeDied();
            //Destroy(gameObject);d
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            healthBar.SetHealth(currentHealth);
            FindObjectOfType<AudioManager>().Play("Heal");

            if (currentHealth >= maxHealth)
                healthBar.SetHealth(maxHealth);
        }
    }
}
