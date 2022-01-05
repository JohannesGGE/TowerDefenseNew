using UnityEngine;

public class Waypoints : MonoBehaviour
{
    /// <summary>
    /// Variable <c> points </c> enthaelt die einzelnen Waypoints
    /// </summary>
    public static Transform[] points;

    /// <summary>
    /// Erstellt die Liste der Waypoints
    /// </summary>
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
