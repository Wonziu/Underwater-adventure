using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PolygonColliderManager : MonoBehaviour
{
    private PolygonCollider2D myPolygonCollider2D;

    private void Start()
    {
        myPolygonCollider2D = GetComponent<PolygonCollider2D>();

        var points = myPolygonCollider2D.points;

        for (int i = 0; i < points.Length; i++)
        {
            int x = (int)points[i].x;
            int y = (int)points[i].y;

            if (x > 0)
                points[i].Set(x + 0.5f, y + 0.5f);
            else points[i].Set(x - 0.5f, y + 0.5f);

        }
        myPolygonCollider2D.points = points;

        DestroyImmediate(this);
    }
}
