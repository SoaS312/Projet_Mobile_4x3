﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BezierSpline : MonoBehaviour
{

    public Transform StartPos, EndPos;


    public Vector3[] points;

    public void Update()
    {
        points[0] = new Vector3((StartPos.position.x - transform.position.x), (StartPos.position.y - transform.position.y), (StartPos.position.z - transform.position.z));
        points[points.Length-1] = new Vector3((EndPos.position.x - transform.position.x), (EndPos.position.y - transform.position.y), (EndPos.position.z - transform.position.z));
        points[1] = new Vector3((points[0].x / 2), 3, 0);
        points[2] = new Vector3((points[0].x / 2), 3, 0);
    }

    public Vector3 GetPoint(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(Bezier.GetPoint(
            points[i], points[i + 1], points[i + 2], points[i + 3], t));
    }

    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(Bezier.GetFirstDerivative(
            points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }

    public void Reset()
    {
        points = new Vector3[] {
            new Vector3(1f, 0f, 0f),
            new Vector3(2f, 0f, 0f),
            new Vector3(3f, 0f, 0f),
            new Vector3(4f, 0f, 0f)
        };
    }

    public void AddCurve()
    {
        Vector3 point = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        point.x += 1f;
        points[points.Length - 3] = point;
        point.x += 1f;
        points[points.Length - 2] = point;
        point.x += 1f;
        points[points.Length - 1] = point;
    }

    public int CurveCount
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }
}