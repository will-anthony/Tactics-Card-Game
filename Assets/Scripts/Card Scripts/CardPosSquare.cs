using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardPosSquare : MonoBehaviour
{

    [SerializeField] private int maxHandSize;
    [SerializeField] private GameObject[] evenCardSlots = new GameObject[12];
    [SerializeField] private GameObject[] oddCardSlots = new GameObject[11];
    [SerializeField] private GameObject drawPileCardSlot;
    [SerializeField] private GameObject discardPileSlot;
    Vector3 cardDistance = new Vector3(0, 0.7f, 0);
    private List<CardHighlighter> hand = new List<CardHighlighter>();
    private bool nextAnimation;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveDeckToDrawPileSlot(List<CardHighlighter> deck)
    {
        foreach(CardHighlighter card in deck)
        {
            transform.position = drawPileCardSlot.transform.position;
        }
    }

    private bool TimeForNextAnimation()
    {
        return nextAnimation;
    }


    public bool AddCardsToHand(List<CardHighlighter> cards)
    {
        
        int nextOpenSlot = MoveCardsDownOneSlot();
//        DrawPileToHandAnimation(card);
        //hand.Add(card);
        //AddNewCardToSlot(card, nextOpenSlot);
        
        return true;
    }

    private int MoveCardsDownOneSlot()
    {

        if(IsEvenHandLength())
        {
            int firstOccupiedSlot = FindStartingSlot(evenCardSlots.Length);
            foreach(CardHighlighter card in hand)
            {
                card.transform.DOMove(oddCardSlots[firstOccupiedSlot - 1].transform.position + cardDistance, 2f);
//                card.transform.position = oddCardSlots[firstOccupiedSlot - 1].transform.position + cardDistance;
                card.transform.rotation = oddCardSlots[firstOccupiedSlot - 1].transform.rotation;
                firstOccupiedSlot++;
            }
            return firstOccupiedSlot - 1;
        } 
        else
        {
            int firstOccupiedSlot = FindStartingSlot(oddCardSlots.Length);
            foreach (CardHighlighter card in hand)
            {
                card.transform.DOMove(oddCardSlots[firstOccupiedSlot].transform.position + cardDistance, 2f);
                card.transform.rotation = evenCardSlots[firstOccupiedSlot].transform.rotation;
                firstOccupiedSlot++;
            }
            return firstOccupiedSlot - 1;
        }
    }

    private void AddNewCardToSlot(CardHighlighter card, int index)
    {
        GameObject[] evenOrOdd = IsEvenHandLength() ? evenCardSlots : oddCardSlots;
        card.transform.DOMove(evenOrOdd[index].transform.position + cardDistance, 2f).Complete(TimeForNextAnimation());
        card.transform.rotation = evenOrOdd[index].transform.rotation;
    }


    //private void DisplayCards()
    //{
    //    GameObject[] evenOrOdd = IsEvenHandLength() ? evenCardSlots : oddCardSlots;
    //    int startingSlot = FindStartingSlot(evenOrOdd.Length);

    //    for (int i = 0; i < hand.Count; i++)
    //    {
    //        hand[i].transform.position = evenOrOdd[startingSlot + i].transform.position + cardDistance;
    //        hand[i].transform.rotation = evenOrOdd[startingSlot + i].transform.rotation;
    //    }
    //}

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

        return emptySlots / 2;
    }

    //public void SetHand(List<CardHighlighter> hand)
    //{
    //    this.hand = hand;
    //    newHand = true;
    //}

    //private void MakeRoomForHighLightedCard(int posInHand)
    //{
    //    if (!hasDeckSplit)
    //    {
    //        savedCardPositions = new List<Vector3>();
    //        float xPosMove = 0.5f;
    //        for (int i = 1; i < 3; i++)
    //        {
    //            if (posInHand + i < hand.Count)
    //            {
    //                savedCardPositions.Add(hand[posInHand + i].transform.position);
    //                hand[posInHand + i].transform.position += new Vector3(xPosMove, 0, 0);
    //            }
    //            if (posInHand - i >= 0)
    //            {
    //                savedCardPositions.Add(hand[posInHand - i].transform.position);
    //                hand[posInHand - i].transform.position -= new Vector3(xPosMove, 0, 0);
    //            }
    //            xPosMove -= 0.2f;
    //        }
    //        hasDeckSplit = true;
    //    }
    //}

    public GameObject GetDrawPileCardSlot()
    {
        return drawPileCardSlot;
    }
    public GameObject GetDiscardPileSlot()
    {
        return discardPileSlot;
    }

}

 
