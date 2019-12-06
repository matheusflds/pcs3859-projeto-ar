using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRopeProjection : MonoBehaviour
{

    private bool insideWater;
    private CountDown timer;
    // Start is called before the first frame update
    void Start()
    {
        CountDown countdown = gameObject.AddComponent(typeof(CountDown)) as CountDown;
        this.timer = countdown;
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ropeContainer = GameObject.Find("RopeContainer");
        int childCount = ropeContainer.transform.childCount;
        GameObject guide = ropeContainer.transform.GetChild(1).gameObject;
        Vector3 pos = guide.transform.position;
        bool submerged = pos.y > 1.0f && pos.y < 3.9f;
        bool mustShowSurfaceContact = false;
        if (submerged) {
            if (!this.insideWater) {
                this.gameObject.transform.position = new Vector3(pos.x, this.transform.position.y, pos.z);
                mustShowSurfaceContact = true;
                this.insideWater = true;
                this.timer.Start();
            }
        } else {
            this.insideWater = false;
        }

        Debug.Log(mustShowSurfaceContact);
        if (mustShowSurfaceContact || this.timer.timeLeft > 0) {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            this.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
