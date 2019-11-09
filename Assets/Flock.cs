using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float speed = 0.001f;
    float rotationSpeed = 1.0f;

    bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.localPosition, Vector3.zero) >= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.localPosition;
            Quaternion quaternion = Quaternion.Slerp(transform.localRotation,
                                                  Quaternion.LookRotation(direction),
                                                  rotationSpeed * Time.deltaTime);
            quaternion.z = 0;
            quaternion.x = 0;
            transform.localRotation = quaternion;
            speed = Random.Range(0.5f, 1);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
            {
                ApplyRules();
            }

        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allFish;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.localPosition, this.transform.localPosition);
                if (dist < 0.1f)
                {
                    groupSize++;
                    vavoid = vavoid + (this.transform.localPosition - go.transform.localPosition);

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        vcenter = goalPos;
        if (groupSize > 0)
        {
            speed = gSpeed / groupSize;
        }

        Vector3 direction = (vcenter + vavoid) - transform.localPosition;

        if (direction != Vector3.zero)
        {

            Quaternion quaternion = Quaternion.Slerp(transform.localRotation,
                                          Quaternion.LookRotation(direction),
                                          rotationSpeed * Time.deltaTime);
            quaternion.z = 0;
            quaternion.x = 0;
            transform.localRotation = quaternion;
        }
    }
}
