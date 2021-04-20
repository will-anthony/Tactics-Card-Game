using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Card")
                {
                    lineRenderer.SetPositions(new Vector3[] { transform.position, new Vector3(2, 2, 2) });
                }
            }
        }
    }
}
