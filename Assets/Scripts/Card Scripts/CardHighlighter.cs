using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlighter : MonoBehaviour
{
    float distance = 2f;
    Vector3 neutralPos;
    Vector3 highlightedPos;


    // Start is called before the first frame update
    void Start()
    {
        neutralPos = transform.position;
        highlightedPos = new Vector3(0, 0.3f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // transform.position = transform.position + Camera.main.transform.forward* distance * Time.deltaTime;

    private void OnMouseEnter()
    {
        transform.position += highlightedPos;
        transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.collider.tag == "Card")
        //    {
        //        transform.position += highlightedPos;
        //        transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        //    }
        //}
    }

    private void OnMouseExit()
    {
        transform.position -= highlightedPos;
        transform.localScale = new Vector3(-0.65f, 0.65f, 0.65f);
    }



}
