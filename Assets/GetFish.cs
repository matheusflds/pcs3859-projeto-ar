using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFish : MonoBehaviour
{
    public GameObject fishManager;
    // Start is called before the first frame update
    void Start()
    {
        fishManager = GameObject.Find("FishManager");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fishManager.transform.childCount; i++)
        {
            GameObject child = fishManager.transform.GetChild(i).gameObject;
            float distance = Vector3.Distance(child.transform.position, this.transform.position);
            Debug.Log("Distance: " + distance);
            if (distance <= 2f) {
                Debug.Log("OI: " + child.ToString());
            }
        }
    }
}
