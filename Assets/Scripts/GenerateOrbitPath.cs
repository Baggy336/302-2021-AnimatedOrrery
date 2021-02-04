using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOrbitPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 600)] public float radius = 5;
    public float sinWaveSkew = 1;
    public float sinPosSkew = 0;
    public float cosWaveSkew = 1;
    public float cosPosSkew = 0;
    public float sinWaveFreq = 1;
    public float sinWaveSet = 0;
    public float cosWaveFreq = 1;
    public float cosWaveSet = 0;
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
            pts[i] = new Vector3(Mathf.Cos(rad * cosWaveFreq + cosWaveSet) * cosWaveSkew + cosPosSkew, 0, (Mathf.Sin(rad * sinWaveFreq + sinWaveSet)) * sinWaveSkew + sinPosSkew) * radius; // A 1 meter long directional output
            rad += Mathf.PI * 2 / num;
        }
        orbit.positionCount = num;
        orbit.SetPositions(pts);
    }
}
