using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezirCurve
{
    public static Vector3 GetPoint(Vector3 startPoint, Vector3 goalPoint, Vector3 controllPoint, float t)
    {
        Vector3 point1 = Vector3.Lerp(startPoint, controllPoint, t);
        Vector3 point2 = Vector3.Lerp(controllPoint, goalPoint, t);
        return Vector3.Lerp(point1, point2, t);
    }
}
