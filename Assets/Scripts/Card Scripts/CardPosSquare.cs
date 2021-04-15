using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPosSquare : MonoBehaviour
{
    /*
    [SerializeField] private CardDisplay card;
    [SerializeField] private int maxHandSize;
    private Vector3[] cardPositions;
    // Start is called before the first frame update
    void Start()
    {
        cardPositions = SetUpCardPositions();

        card.transform.position = this.transform.position;
        card.transform.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private Vector3[] SetUpCardPositions()
    {
        Vector3 cardToCameraPadding = new Vector3(0, 1f, 0);
        Vector3 distance = this.transform.position + cardToCameraPadding;

        Vector3[] temp = new Vector3[12];
        temp[0] = distance;
        temp[1] = distance + new Vector3(1, 0, 0);
        temp[2] = distance + new Vector3(-1, 0, 0);
        temp[3] = distance + new Vector3(2, 0, 0);
        temp[4] = distance + new Vector3(-2, 0, 0);
        temp[5] = distance + new Vector3(3, 0, 0);
        temp[6] = distance + new Vector3(-3, 0, 0);
        temp[7] = distance + new Vector3(4, 0, 0);
        temp[8] = distance + new Vector3(-4, 0, 0);
        temp[9] = distance + new Vector3(5, 0, 0);
        temp[10] = distance + new Vector3(-5, 0, 0);
        temp[11] = distance + new Vector3(6, 0, 0);
        return temp;
    }

    public void DisplayDeck(List<CardDisplay> cards)
    {
        // check that the current hand size is not too big to display
        int cardNumber = cards.Count;
        if (cardNumber > maxHandSize)
        {
            cardNumber = maxHandSize;
        }
  
        for(int i = 0; i <= cardNumber; i++)
        {
            cards[i].transform.position = cardPositions[i];
        }
    }
    */

}

 
