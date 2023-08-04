using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        //Debug.Log("childCount: " + this.transform.childCount);
        points = new Transform[this.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = this.transform.GetChild(i);
        }
    }
}
