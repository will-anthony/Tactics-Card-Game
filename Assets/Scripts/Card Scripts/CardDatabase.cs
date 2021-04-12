using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<CardScript> cardList = new List<CardScript>();

    void Awake()
    {
        cardList.Add(new CardScript(0, "Power Punch", 3, 10, "Deal 10 Damage"));
        cardList.Add(new CardScript(1, "Ground Smash", 2, 5, "Deal 5 Damage to every adjacent space"));
        cardList.Add(new CardScript(2, "Beat Chest", 4, 0, "Reduce incoming damage by 50%"));
        cardList.Add(new CardScript(3, "Death Punch", 6, 20, "Deal 20 Damage"));
        cardList.Add(new CardScript(4, "Howl", 3, 0, "Terrify all enemies within 6 spaces"));
    }
}
