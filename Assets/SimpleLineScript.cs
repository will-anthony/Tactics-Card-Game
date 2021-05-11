using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isCardClicked;
    private bool isLineTurnedOn;
    [SerializeField]private Camera cam;
    List<Vector3> linepoints = new List<Vector3>();

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        isCardClicked = false;
        isLineTurnedOn = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //if (GetComponent<CardHighlighter>().IsCardSelected())
        //{
        //    this.displayline();
        //}
    }
       

    private void displayline()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Card Clicked!");
            return;
        }
        
        linepoints.Add(transform.position);
        linepoints.Add(cam.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPositions(linepoints.ToArray());

    }

    private void TurnLineOff()
    {
        linepoints.Clear();
        lineRenderer.SetPositions(linepoints.ToArray());
    }
}
