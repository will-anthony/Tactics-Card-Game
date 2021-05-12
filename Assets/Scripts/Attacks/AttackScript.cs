using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    private bool isAttacking = false; 

    void Start()
    {
        
    }

    void Update()
    {
        List<CardHighlighter> cards = GetComponent<PlayerDeck>().GetDeck();
        foreach (CardHighlighter card in cards)
        {
            if (card.IsCardClicked())
            {
                isAttacking = true;
                return;
            }
            isAttacking = false;
        }

        if(isAttacking)
        {
            CalculateAttackArea();
        }
    }

    private void CalculateAttackArea()
    {

    }
}
