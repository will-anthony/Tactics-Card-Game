using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public AttackCard card;

    public Text nameText;
    public Text descriptionText;
    public Image artwork;
    public Text staminaText;

    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        artwork.sprite = card.artwork;
        staminaText.text = card.staminaCost.ToString();
    }
}
