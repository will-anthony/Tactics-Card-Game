using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlighter : MonoBehaviour
{
    private bool isHighlighted = false;

    // transform
    private float additionalXPos = 0;
    private float additionalYPos = 0;
    private float additionalZPos = -1f;
    private Vector3 originalPos;
    // rotation
    private Quaternion verticalRotation = Quaternion.Euler(0,0,0);
    private Quaternion originalRotation;
    // scale
    private Vector3 highlightedScale = new Vector3(-0.8f, 0.8f, 0.8f);
    private Vector3 originalScale = new Vector3(-0.65f, 0.65f, 0.65f);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // transform.position = transform.position + Camera.main.transform.forward* distance * Time.deltaTime;

    private void OnMouseEnter()
    {
        originalPos = transform.position;
        transform.position = CalculateHighlightedPos();
        transform.localScale = highlightedScale;
        originalRotation = transform.rotation;
        transform.rotation = verticalRotation;
        isHighlighted = true;
    }

    private void OnMouseExit()
    {
        transform.position = originalPos;
        transform.localScale = originalScale;
        if(originalRotation != null)
        {
            transform.rotation = originalRotation;
        }
        isHighlighted = false;
    }


    private Vector3 CalculateHighlightedPos()
    {
        float highlightedXpos = transform.position.x + additionalXPos;
        float diffInY = -2 - transform.position.y; 
        float highlightedYPos = transform.position.y + additionalYPos + diffInY;
        float highlightedZPos = transform.position.z + additionalZPos;
        return new Vector3(highlightedXpos, highlightedYPos, highlightedZPos);
    }

    public bool getHighlighted()
    {
        return isHighlighted;
    }
}
