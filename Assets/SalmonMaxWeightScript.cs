﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SalmonMaxWeightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fishImage = SalmonCatalogScript.fishImage;
        string weight = SalmonCatalogScript.maxWeight;

        TextMeshProUGUI fishMaxWeightComponent = GetComponent<TextMeshProUGUI>();

        if (fishImage == true)
        {
            fishMaxWeightComponent.text = weight;
        }
    }
}