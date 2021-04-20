using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererScript : MonoBehaviour
{
    [SerializeField] int resolution = 12;
    private Vector3 origin;
    private Vector3 midPoint;
    private Vector3 destination;
    private LineRenderer lineRenderer;
    private float midPointYPos = 2;

    private void Awake()
    {
        origin = transform.parent.position;
        midPoint = transform.parent.position;
        destination = transform.parent.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        
    }

    void Update()
    {
 //       origin = transform.parent.position;
     //   destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        midPoint = new Vector3((origin.x + destination.x),
            midPointYPos, (origin.z + destination.z) / 2);

        List<Vector3> pointList = new List<Vector3>();
        for (float ratio = 0; ratio <= 1; ratio += 1/ resolution)
        {
            Vector3 tangent1 = Vector3.Lerp(origin, midPoint, ratio);
            Vector3 tangent2 = Vector3.Lerp(midPoint, destination, ratio);
            Vector3 curve = Vector3.Lerp(tangent1, tangent2, ratio);

            pointList.Add(curve);
        }

        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }
}
