using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isCardClicked;
    private bool isLineTurnedOn;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        isCardClicked = false;
        isLineTurnedOn = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLineTurnedOn)
        {
            Debug.Log("MouseDown");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Card")
                {
                    isLineTurnedOn = true;
                    isCardClicked = true;
                }
            }
        }

        if(isCardClicked)
        {
            DisplayLine();
        } else
        {
            TurnLineOff();
        }

        if(Input.GetMouseButtonUp(0) && isLineTurnedOn)
        {
            Debug.Log("MouseUp");

            isCardClicked = false;

        }
    }

    private void TurnLineOff()
    {
        lineRenderer.SetPositions(new Vector3[] { transform.position });

    }

    private void DisplayLine()
    {
        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Cube")
            {
                linePoints.Add(hit.transform.position);
                lineRenderer.SetPositions(linePoints.ToArray());
            }
        }
    }
}
