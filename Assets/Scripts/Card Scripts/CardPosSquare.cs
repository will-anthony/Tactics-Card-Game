using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPosSquare : MonoBehaviour
{
    
    [SerializeField] private int maxHandSize;
    [SerializeField] private GameObject[] evenCardSlots = new GameObject[12];
    [SerializeField] private GameObject[] oddCardSlots = new GameObject[11];
    private List<CardDisplay> hand;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           if(hand != null && hand.Count <= maxHandSize)
        {
            DisplayCards();
        } 
    }

    private void DisplayCards()
    {
        GameObject[] evenOrOdd = IsEvenHandLength() ? evenCardSlots : oddCardSlots;
        int startingSlot = FindStartingSlot(evenOrOdd.Length);

        Vector3 cardDistance = new Vector3(0, 0.7f, 0); 

        for(int i = 0; i < hand.Count; i++)
        {
            hand[i].transform.position = evenOrOdd[startingSlot + i].transform.position + cardDistance;
        }
    }

    private bool IsEvenHandLength()
    {
        if (hand.Count % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int FindStartingSlot(int totalSlots)
    {
        int emptySlots = (totalSlots - hand.Count);
        if (emptySlots <= 0)
        {
            return 0;
        }

        return emptySlots / 2 - 1;
    }

    public void SetHand(List<CardDisplay> hand)
    {
        this.hand = hand; 
    }

}

 
