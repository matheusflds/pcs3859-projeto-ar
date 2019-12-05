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
    }

    // Update is called once per frame
    void Update()
    {
        float waterY = 0.1f;
        GameObject ropeContainer = GameObject.Find("RopeContainer");
        int childCount = ropeContainer.transform.childCount;
        GameObject guide = ropeContainer.transform.GetChild(1).gameObject;
        Vector3 pos = guide.transform.position;
        // this.gameObject.transform.eulerAngles = new Vector3(0, 90.86f, 0);
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
        // if (!mustShowSurfaceContact && this.transform.localScale != new Vector3(0,0,0)) {
        //     this.transform.localScale = new Vector3(0,0,0);
        // } else if (mustShowSurfaceContact && this.transform.localScale != new Vector3(0.0085f, 0.0032f, 0.0032f)) {
        //     this.transform.localScale = new Vector3(0.0085f, 0.0032f, 0.0032f);
        // }

        // this.gameObje ct.SetActive(Mathf.Abs(pos.y - 0.1f) < 2.415f);
        // Debug.Log(Mathf.Abs(pos.y - 0.1f) < 2.415f);
        // for (int i = 0; i < childCount; i++)
        // {
        //     GameObject ropeParts = ropeContainer.transform.GetChild(i).gameObject;
        //     Vector3 pos = ropeParts.transform.position;
        //     Debug.Log("Part " + i + pos);
        //     if (Mathf.Abs(pos.y - waterY) <= 0.02) {
        //         this.gameObject.transform.position = new Vector3(pos.x, this.transform.position.y, pos.z);
        //         // this.gameObject.SetActive(true);
        //     }
        // } 

    }
}
