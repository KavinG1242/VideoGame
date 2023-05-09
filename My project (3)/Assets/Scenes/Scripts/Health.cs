using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public HealthBar healthBar;

    public int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Heal(10);
        }
    }
    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        healthBar.SetMaxHealth(health);
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }
        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
            healthBar.SetMaxHealth(health);

        }
        else
        {
            this.health += amount;
            healthBar.SetHealth(health);
        }



    }
    private void Die()
    {
        Debug.Log("RIP UR DED");
        Destroy(gameObject);
    }
}
