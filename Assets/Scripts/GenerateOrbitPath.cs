using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOrbitPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 300)] public float radius = 5;
    LineRenderer orbit;

    private void Start()
    {
        GenerateOrbit();
    }
    private void OnValidate()
    {
        GenerateOrbit();
    }

    void GenerateOrbit()
    {
        orbit = GetComponent<LineRenderer>();

        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius; // A 1 meter long directional output
            rad += Mathf.PI * 2 / num;
        }
        orbit.positionCount = num;
        orbit.SetPositions(pts);
    }
}
