using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerScript : MonoBehaviour
{
    private Health health;
    private bool inAttackPhase = false;

    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
        healthBar.SetMaxHealth(health.GetMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAttackPhase)
        {
            gameObject.GetComponent<PlayerMove>().InitiateMovementPhase();
        }
        else
        {
            gameObject.GetComponent<PlayerMove>().RemoveSelectableTiles();
            Debug.Log("Attack Phase");
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            inAttackPhase = !inAttackPhase;
        }
    }

    void TakeDamage(int damage)
    {
        health.DecreaseHealth(5);
        healthBar.SetHealth(health.GetHealth());
    }
}
