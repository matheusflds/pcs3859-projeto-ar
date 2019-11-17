using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampAngularMovement : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hasReachedMaxVelocity = rb.velocity.magnitude > 2f;
        bool isReachingZeroVelocity = rb.velocity.magnitude > 1f && rb.velocity.magnitude < 1.2f;
        if (hasReachedMaxVelocity || isReachingZeroVelocity)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

    }
}
