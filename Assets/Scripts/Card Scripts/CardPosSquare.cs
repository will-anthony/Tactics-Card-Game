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
    private const float CARD_DRAW_SPEED = 0.2f;
    private Vector3 cardDistance = new Vector3(0, 0.7f, 0);
    private List<CardHighlighter> hand = new List<CardHighlighter>();
    private bool addNextCard = true;
    private Queue<CardHighlighter> queuedCards = new Queue<CardHighlighter>();

    void Update()
    {
        AddCardFromQueueToHand();
    }

    public void AddCardToQueue(CardHighlighter card)
    {
        queuedCards.Enqueue(card);
    }

    private void AddCardFromQueueToHand()
    {
        if (queuedCards.Count > 0 && addNextCard)
        {
            addNextCard = false;
            CardHighlighter card = queuedCards.Dequeue();
            int nextOpenSlot = MoveCardsDownOneSlot();
            GameObject[] evenOrOdd = IsEvenHandLength() ? oddCardSlots : evenCardSlots ;

            card.transform.rotation = evenOrOdd[nextOpenSlot].transform.rotation;
            card.transform.DOMove(evenOrOdd[nextOpenSlot].transform.position + cardDistance, CARD_DRAW_SPEED).OnComplete(()=>
            {
                addNextCard = true;
                hand.Add(card);
            });
        }
    }

    private int MoveCardsDownOneSlot()
    {

        if(IsEvenHandLength())
        {
            int firstOccupiedSlot = FindStartingSlot(evenCardSlots.Length);
            foreach(CardHighlighter card in hand)
            {
                card.transform.DOMove(oddCardSlots[firstOccupiedSlot - 1].transform.position + cardDistance, CARD_DRAW_SPEED);
                card.transform.DORotate(oddCardSlots[firstOccupiedSlot - 1].transform.rotation.eulerAngles, CARD_DRAW_SPEED);
                firstOccupiedSlot++;
            }
            return firstOccupiedSlot - 1;
        } 
        else
        {
            int firstOccupiedSlot = FindStartingSlot(oddCardSlots.Length);
            foreach (CardHighlighter card in hand)
            {
                card.transform.DOMove(evenCardSlots[firstOccupiedSlot].transform.position + cardDistance, CARD_DRAW_SPEED);
                card.transform.DORotate(evenCardSlots[firstOccupiedSlot].transform.rotation.eulerAngles, CARD_DRAW_SPEED);
                firstOccupiedSlot++;
            }
            return firstOccupiedSlot;
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

        return emptySlots / 2;
    }

    public void MoveDeckToDrawPileSlot(List<CardHighlighter> deck)
    {
        foreach (CardHighlighter card in deck)
        {
            transform.position = drawPileCardSlot.transform.position;
        }
    }

    public GameObject GetDrawPileCardSlot()
    {
        return drawPileCardSlot;
    }
    public GameObject GetDiscardPileSlot()
    {
        return discardPileSlot;
    }

}

 
