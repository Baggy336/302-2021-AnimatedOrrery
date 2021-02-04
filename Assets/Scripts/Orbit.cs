using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // TODO: Transform.Rotate on a certain object
    // Use the spotOnCircleXZ function

    // Declare variables to hold radius, and age of the object.
    public Transform target;

    public float radius = 2;
    public float speed = 0;
    private float age = 0;
    public float sinSkew = 0;
    public float cosSkew = 0;
    public float sinPosSkew = 0;
    public float cosPosSkew = 0;
    public float sinWaveFreq = 1;
    public float sinWaveSet = 0;
    public float cosWaveFreq = 1;
    public float cosWaveSet = 0;

    void Update()
    {
        // Update the time since last frame multiplied by the speed, and add that to the age. 
        age += (speed * Time.deltaTime);

        // Create a vector that moves a point on a radius based on age.
        Vector3 offset = AnimMath.SpotOnCircleXZ(radius, age, sinSkew, sinPosSkew, sinWaveFreq, sinWaveSet, cosSkew, cosPosSkew, cosWaveFreq, cosWaveSet);

        // Using the calculated offset, transform the object 
        transform.position = target.position + offset;

        // Manipulate the speed of the moving object
        
    }
}
