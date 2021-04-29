﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] List<CardDisplay> deck = new List<CardDisplay>();
    private bool cardsSet = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerMove>().turn == true && cardsSet == false)
        {
            GameObject.Find("DeckHandler").GetComponent<DeckHandlerScript>().SetHand(deck);
            cardsSet = true;
        }

        if (GetComponent<PlayerMove>().turn == false)
        {
            cardsSet = false;
        }
    }
}
