using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSizeScript : MonoBehaviour
{
    Vector3 size, position;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        UpdateComponentSizeAndPos();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerVec = Input.gyro.attitude.eulerAngles;
        transform.eulerAngles = new Vector3(-1.0f * eulerVec.x, -1.0f * eulerVec.y, eulerVec.z);
        // gameObject.GetComponent<Renderer>().enabled = true;
    }

    private void UpdateComponentSizeAndPos()
    {
        size = transform.localScale;
        position = transform.position;

        float screenWidth = Display.main.systemWidth;
        float screenHeight = Display.main.systemHeight;

        size.x = screenWidth * 0.05f;
        size.y = screenHeight * 0.25f;
        size.z = size.x;

        // position.x = position.x + screenWidth * 0.15f;
        // position.y = position.y - screenHeight * 0.25f;

        transform.localScale = size;
        transform.position = position;
    }
}
