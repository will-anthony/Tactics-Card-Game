using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CardScript : MonoBehaviour
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public CardScript()
    {

    }

    public CardScript(int Id, string CardName, int Cost, int Power, string CardDescription)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;

    }
}
