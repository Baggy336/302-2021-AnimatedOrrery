using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Declare a target to follow
    public Transform target;

    void Update()
    {
        // Every frame, update the object's position to move towards it's target
        transform.position = AnimMath.Slide(transform.position, target.position, .01f);
    }
}
