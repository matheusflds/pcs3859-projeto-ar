using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public float strengthOfAttraction = 5.0f;

    void FixedUpdate()
    {
        GameObject attractedTo = GameObject.Find("Water");
        Vector3 direction = attractedTo.transform.position - transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
    }

}
