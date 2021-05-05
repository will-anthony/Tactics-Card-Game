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

    private float fullCardPush = 0.6f;
    private float halfCardPush = 0.4f;
    private float quarterCardPush = 0.2f;
    private Vector3 pushDistance;
    // rotation
    private Quaternion verticalRotation = Quaternion.Euler(0,0,0);
    // scale
    private Vector3 highlightedScale = new Vector3(-0.8f, 0.8f, 0.8f);
    private Vector3 originalScale = new Vector3(-0.65f, 0.65f, 0.65f);
    private float cardHeightY = 0.7f;
    private Vector3 cardHeight = new Vector3(0, 0.7f, 0);
    private Vector3 selectedCardPosition = new Vector3(-22.7f,-2.96f,8.54f);
    private Transform currentCardSlot;
    private CardHighlighter leftCard;
    private CardHighlighter rightCard;

    private void OnMouseEnter()
    {
        isHighlighted = true;

        DOTween.KillAll(this);
        transform.DOMove(CalculateHighlightedPos(), 0f);
        transform.DOScale(highlightedScale, 0f);
        transform.DORotate(verticalRotation.eulerAngles, 0f);
        CheckWhetherToPushCards(); 
    }

    private void OnMouseExit()
    {
        isHighlighted = false;
        transform.DOMoveX(currentCardSlot.position.x, 0.3f);
        transform.DOMoveY(currentCardSlot.position.y + 0.7f, 0.3f);
        transform.DOMoveZ(currentCardSlot.position.z, 0f);


        transform.DOScale(originalScale, 0.5f);
        transform.DORotate(currentCardSlot.rotation.eulerAngles, 0.3f);
        CheckWhetherToResetCards();
    }

    private void OnMouseDown()
    {
        
    }

    private Vector3 CalculateHighlightedPos()
    {
        float highlightedXpos = currentCardSlot.position.x + additionalXPos;
        float diffInY = -2 - currentCardSlot.position.y; 
        float highlightedYPos = currentCardSlot.position.y + additionalYPos + diffInY;
        float highlightedZPos = currentCardSlot.position.z + additionalZPos;
        return new Vector3(highlightedXpos, highlightedYPos, highlightedZPos);
    }

    private void CheckWhetherToPushCards()
    {
        if (rightCard != null)
        {
            PushCardAside(rightCard, true, fullCardPush);
            if (rightCard.getRightCard() != null)
            {
                PushCardAside(rightCard.getRightCard(), true, halfCardPush);
                if (rightCard.getRightCard().getRightCard() != null)
                {
                    PushCardAside(rightCard.getRightCard().getRightCard(), true, quarterCardPush);
                }
            }
        }
        if (leftCard != null)
        {
            PushCardAside(leftCard, false, fullCardPush);
            if (leftCard.getLeftCard() != null)
            {
                PushCardAside(leftCard.getLeftCard(), false, halfCardPush);
                if (leftCard.getLeftCard().getLeftCard() != null)
                {
                    PushCardAside(leftCard.getLeftCard().getLeftCard(), false, quarterCardPush);
                }
            }
        }
    }

    private void CheckWhetherToResetCards()
    {
        if (rightCard != null)
        {
            ReturnCard(rightCard);
            if (rightCard.getRightCard() != null)
            {
                ReturnCard(rightCard.getRightCard());
                if (rightCard.getRightCard().getRightCard() != null)
                {
                    ReturnCard(rightCard.getRightCard().getRightCard());
                }
            }
        }
        if (leftCard != null)
        {
            ReturnCard(leftCard);
            if (leftCard.getLeftCard() != null)
            {
                ReturnCard(leftCard.getLeftCard());
                if (leftCard.getLeftCard().getLeftCard() != null)
                {
                    ReturnCard(leftCard.getLeftCard().getLeftCard());
                }
            }
        }
    }

    private void PushCardAside(CardHighlighter card, bool right, float distance)
    {
        int direction = right ? 1 : -1;
        pushDistance = new Vector3((distance * direction), 0, 0);
        card.transform.DOMove(card.GetCardSlotPos().position + pushDistance + cardHeight, 0.8f);
    }

    private void ReturnCard(CardHighlighter card) {
        
        card.transform.DOMove(card.GetCardSlotPos().position + cardHeight, 0.8f);
    }


    public bool IsHighlighted()
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
    public void setleftCard(CardHighlighter leftCard)
    {
        this.leftCard = leftCard;
    }
    public CardHighlighter getLeftCard()
    {
        return this.leftCard;
    }
    public CardHighlighter getRightCard()
    {
        return this.rightCard;
    }
    public void setRightCard(CardHighlighter rightCard)
    {
        this.rightCard = rightCard;
    }
}
