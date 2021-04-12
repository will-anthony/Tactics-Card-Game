using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void IncreaseHealth(int health)
    {
        if (this.health + health >= maxHealth)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += health;
        }
    }

    public void DecreaseHealth(int health)
    {
        if (this.health - health <= 0)
        {
            Death();
        }
        else
        {
            this.health -= health;
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
    
    
