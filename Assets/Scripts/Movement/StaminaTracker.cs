using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaTracker : MonoBehaviour
{

    [SerializeField] private const int MAXSTAMINA = 10;
    [SerializeField] private int currentStamina = 10;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public int GetStamina()
    {
        return currentStamina;
    }

    public bool RequestStamina(int amount)
    {
        if(amount <= currentStamina)
        {
            currentStamina -= amount;
            return true;
        }

        return false;
    }

    public void AddStamina(int stamina)
    {
        if (stamina + currentStamina >= MAXSTAMINA)
        {
            currentStamina = MAXSTAMINA;
        }
        else
        {
            currentStamina += stamina;
        }
    }
}
