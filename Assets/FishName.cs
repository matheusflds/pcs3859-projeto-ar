using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishName : MonoBehaviour
{
    private TextMeshProUGUI fishNameComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string fishName;

        fishNameComponent = GetComponent<TextMeshProUGUI>();
        fishName = FishDetails.fishName;

        if (fishName == "tuna")
        {
            fishNameComponent.text = "Atum";
        }
        else
        {
            fishNameComponent.text = "Salmão";
        }
    }
}
