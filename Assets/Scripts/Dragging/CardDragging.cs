using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragging : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        CheckMouse();
    }

    private void CheckMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Card")
            {
                Debug.Log("Card " + hit.collider.name + " clicked");
            }
        }
        
    }
}
