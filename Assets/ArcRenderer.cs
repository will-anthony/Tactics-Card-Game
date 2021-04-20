using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArcRenderer : MonoBehaviour
{
    private LineRenderer lineRendeder;

    public float velocity;
    public float angle;
    public int resolution;
    float gravity;
    float radianAngle;

    private void Awake()
    {
        lineRendeder = GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics2D.gravity.y);
    }
    void Start()
    {
        RenderArc();
    }

    private void OnValidate()
    {
        if (lineRendeder != null && Application.isPlaying)
        {
            RenderArc();
        }
    }

    void RenderArc()
    {
        lineRendeder.positionCount = resolution + 1;
        lineRendeder.SetPositions(CalculateArcArray());
    }

    private Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        // may want to change distance to where mouse is pointing
        float distance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / gravity;

        for(int i = 0; i <= resolution; i++)
        {
            float point = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(point, distance);
        }

        return arcArray;
    }

    private Vector3 CalculateArcPoint(float point, float distance)
    {
        float x = point * distance;
        float y = x * Mathf.Tan(radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }

 
}
