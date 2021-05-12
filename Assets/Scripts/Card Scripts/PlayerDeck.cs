using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    private const string DECK_HANDLER_NAME = "DeckHandler";
    [SerializeField] List<CardHighlighter> deck = new List<CardHighlighter>();
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
            GameObject.Find(DECK_HANDLER_NAME).GetComponent<DeckHandlerScript>().SetNewDeck(deck);
            cardsSet = true;
        }

        if (GetComponent<PlayerMove>().turn == false)
        {
            cardsSet = false;
        }
    }

    public List<CardHighlighter> GetDeck()
    {
        return deck;
    }
}
