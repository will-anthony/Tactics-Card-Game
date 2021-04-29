using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandlerScript : MonoBehaviour
{
    List<CardDisplay> currentDeck = new List<CardDisplay>();
    bool changeDeck = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (GetComponent<PlayerMove>().turn == true && cardsSet == false)
        {
            GameObject.Find("DeckHandler").GetComponent<DeckHandlerScript>().SetHand(deck);
            cardsSet = true;
        }

        if (GetComponent<PlayerMove>().turn == false)
        {
            cardsSet = false;
        }
    }

    public void SetHand(List<CardDisplay> deck)
    {
        this.currentDeck = deck;
    }

}
