using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public CardSO card;

    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text staminaText;
    public Text attackText;


    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description.ToString();
        artworkImage.sprite = card.artwork;
        staminaText.text = card.staminaCost.ToString();
    }

}
