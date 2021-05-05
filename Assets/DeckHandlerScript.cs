using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandlerScript : MonoBehaviour
{
    private const int MAX_HAND_SIZE = 10;
    private List<CardHighlighter> wholeDeck = new List<CardHighlighter>();
    private Stack<CardHighlighter> drawPile;
    private List<CardHighlighter> discardPile = new List<CardHighlighter>();
    private List<CardHighlighter> hand = new List<CardHighlighter>();
    bool changeDeck = false;

    void Start()
    {

    }

    public void SetNewDeck(List<CardHighlighter> wholeDeck)
    {
        this.wholeDeck = wholeDeck;
//        GameObject.Find("Card Slots").GetComponent<CardPosSquare>().MoveDeckToDrawPileSlot(wholeDeck);
        RefreshDrawPile(wholeDeck);
        DrawCards(9);
    }

    private void RefreshDrawPile(List<CardHighlighter> deck)
    {
        deck = ShuffleDeck(deck);
        drawPile = new Stack<CardHighlighter>(deck);
    }

    public void DrawCards(int numberOfCards)
    {
        if (numberOfCards > MAX_HAND_SIZE)
        {
            numberOfCards = MAX_HAND_SIZE;
        }

        for (int i = 0; i < numberOfCards; i++)
        {
            CardHighlighter card = DrawOneCard();
            hand.Add(card);
            GameObject.Find("Card Slots").GetComponent<CardPosSquare>().AddCardToQueue(card);
        }
    }

    private CardHighlighter DrawOneCard()
    {
        if(drawPile.Count > 0)
        {
            return drawPile.Pop();
        } 
        else
        {
            RefreshDrawPile(discardPile);
            return DrawOneCard();
        }
    }

    private List<CardHighlighter> ShuffleDeck(List<CardHighlighter> deck)
    {
        int count = deck.Count;
        int last = count - 1;
        for (int i = 0; i < last; ++i)
        {
            int randomInt = Random.Range(i, count);
            CardHighlighter card = deck[i];
            deck[i] = deck[randomInt];
            deck[randomInt] = card;
        }

        return deck;
    }

    public void DiscardCard(CardHighlighter card)
    {
        hand.Remove(card);
        discardPile.Add(card);
    }

}
