using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public new string name;
    public string description;
    public CharacterAsset characterAsset;

    public Sprite artwork;

    public int staminaCost;
    public string cardType;
    public int health;
}
