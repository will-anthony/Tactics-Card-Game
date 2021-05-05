using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardHighlighter : MonoBehaviour
{
    private bool isHighlighted = false;
    
    // transform
    private float additionalXPos = 0;
    private float additionalYPos = 0;
    private float additionalZPos = -1f;
    private Vector3 temp = new Vector3(0.1f, 0, 0);
    // rotation
    private Quaternion verticalRotation = Quaternion.Euler(0,0,0);
    // scale
    private Vector3 highlightedScale = new Vector3(-0.8f, 0.8f, 0.8f);
    private Vector3 originalScale = new Vector3(-0.65f, 0.65f, 0.65f);
    private Vector3 cardHeight = new Vector3(0, 0.7f, 0);
    private Transform currentCardSlot;
    private CardHighlighter leftCard;
    private CardHighlighter rightCard;

    private void OnMouseEnter()
    {
        DOTween.KillAll(this);
        transform.DOMove(CalculateHighlightedPos(), 0f);
        transform.DOScale(highlightedScale, 0f);
        transform.DORotate(verticalRotation.eulerAngles, 0f);
        PushCardAside(rightCard);
        PushCardAside(leftCard);
        isHighlighted = true;
    }

    private void OnMouseExit()
    {
        transform.DOMove(currentCardSlot.position + cardHeight, 0.5f);
        transform.DOScale(originalScale, 0.5f);
        transform.DORotate(currentCardSlot.rotation.eulerAngles, 0.5f);
    }

    private Vector3 CalculateHighlightedPos()
    {
        float highlightedXpos = currentCardSlot.position.x + additionalXPos;
        float diffInY = -2 - currentCardSlot.position.y; 
        float highlightedYPos = currentCardSlot.position.y + additionalYPos + diffInY;
        float highlightedZPos = currentCardSlot.position.z + additionalZPos;
        return new Vector3(highlightedXpos, highlightedYPos, highlightedZPos);
    }

    private void PushCardAside(CardHighlighter card)
    {
        card.transform.DOMove(card.GetCardSlotPos().position + temp, 1f);
    }


    public bool getHighlighted()
    {
        return isHighlighted;
    }

    public void setCardSlotPos(Transform currentCardSlot)
    {
        this.currentCardSlot = currentCardSlot;
    }

    public Transform GetCardSlotPos()
    {
        return this.currentCardSlot;
    }

    public void setleftHandCard(CardHighlighter leftCard)
    {
        this.leftCard = leftCard;
    }

    public void setRightHandCard(CardHighlighter rightCard)
    {
        this.rightCard = rightCard;
    }
}
