using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardHighlighter : MonoBehaviour
{   
    // transform
    private float additionalZPos = -1f;
    // rotation
    private Quaternion verticalRotation = Quaternion.Euler(0,0,0);
    // scale
    private Vector3 highlightedScale = new Vector3(-0.8f, 0.8f, 0.8f);
    private Vector3 clickedPos = new Vector3(-22, 0.4f, 1);

    private bool isCardHighlighted;
    private bool isCardClicked;
    private Transform currentCardSlot;
    private Sequence highlightedTween;
    private Sequence clickedTween;

    private void OnMouseEnter()
    {  
        
        if (highlightedTween == null)
        {
            highlightedTween = InitializeTween(highlightedTween, CalculateHighlightedPos(), highlightedScale, verticalRotation, 0.1f);
        }
        highlightedTween.PlayForward();       
    }

    private void OnMouseExit()
    {
        if (!isCardClicked)
        {
            highlightedTween.PlayBackwards();
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

    private void OnMouseDown()
    {
        isCardClicked = true;
        this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1,0.784f,0,0.901f);
    }

    private void OnMouseUp()
    {
        isCardClicked = false;
        this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(0.525f, 0.992f, 1, 0.803f);
        if (highlightedTween != null)
        {
            highlightedTween.PlayBackwards();
        }
    }

    private Vector3 CalculateHighlightedPos()
    {
        float highlightedXpos = currentCardSlot.position.x;
        float diffInY = -2 - currentCardSlot.position.y; 
        float highlightedYPos = currentCardSlot.position.y + diffInY;
        float highlightedZPos = currentCardSlot.position.z + additionalZPos;
        return new Vector3(highlightedXpos, highlightedYPos, highlightedZPos);
    }

    public void setCardSlotPos(Transform currentCardSlot)
    {
        this.currentCardSlot = currentCardSlot;
    }

}
