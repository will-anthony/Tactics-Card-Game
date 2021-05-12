using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardHighlighter : MonoBehaviour
{
    // transforms
    private Transform currentCardSlot;
    private float additionalZPos = -1f;
    // images
    private Image childGlowImage;
    //colors
    private Color blueGlow = new Color(0.525f, 0.992f, 1, 0.803f);
    private Color goldGlow = new Color(1, 0.784f, 0, 0.901f);
    // rotation
    private Quaternion verticalRotation = Quaternion.Euler(0, 0, 0);
    // scale
    private Vector3 highlightedScale = new Vector3(-0.8f, 0.8f, 0.8f);
    // booleans
    private bool isCardInteractable = false;
    private bool isCardClicked;
    // tweens
    private Sequence highlightedTween;

    private void Awake()
    {
        childGlowImage = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    }

    private void OnMouseEnter()
    {
        if (isCardInteractable)
        {
            if (highlightedTween == null)
            {
                highlightedTween = InitializeTween(highlightedTween, CalculateHighlightedPos(), highlightedScale, verticalRotation, 0.1f);
            }
            highlightedTween.PlayForward();
        }
    }

    private void OnMouseExit()
    {
        if (isCardInteractable)
        {
            if (!isCardClicked)
            {
                highlightedTween.PlayBackwards();
            }
        }
    }
    private void OnMouseDown()
    {
        if (isCardInteractable)
        {
            isCardClicked = true;
            childGlowImage.color = goldGlow;
        }
    }

    private void OnMouseUp()
    {
        if (isCardInteractable)
        {
            isCardClicked = false;
            childGlowImage.color = blueGlow;
            if (highlightedTween != null)
            {
                highlightedTween.PlayBackwards();
            }
        }
    }
    private Sequence InitializeTween(Sequence sequence, Vector3 position, Vector3 scale, Quaternion rotation, float speed)
    {
        sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOMove(position, speed));
        sequence.Insert(0, transform.DOScale(scale, speed));
        sequence.Insert(0, transform.DORotate(rotation.eulerAngles, speed));
        sequence.SetAutoKill(false);
        return sequence;
    }

    private Vector3 CalculateHighlightedPos()
    {
        float highlightedXpos = currentCardSlot.position.x;
        float diffInY = -2 - currentCardSlot.position.y;
        float highlightedYPos = currentCardSlot.position.y + diffInY;
        float highlightedZPos = currentCardSlot.position.z + additionalZPos;
        return new Vector3(highlightedXpos, highlightedYPos, highlightedZPos);
    }

    public void SetCardSlotPos(Transform currentCardSlot)
    {
        this.currentCardSlot = currentCardSlot;
    }
    public void SetCardInteractable(bool onOrOff)
    {
        this.isCardInteractable = onOrOff;
    }
    public bool IsCardClicked() 
    {
        return isCardClicked;
    }

}
