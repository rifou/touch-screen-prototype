using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class line : MonoBehaviour
{
public LineRenderer lineRenderer;
List<Vector2> points;
    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void UpdatePoints(Vector2 point)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoints(point);
            return;
        }
        if (Vector2.Distance(points.Last(), point) > 0.1f)
        {
            SetPoints(point);
        }
    }

    public void SetPoints(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count-1,point);
       // lineRenderer.SetPosition(0, lineRenderer.GetPosition(1));
    }
}
