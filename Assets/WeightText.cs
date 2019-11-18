using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightText : MonoBehaviour
{
    private TextMeshProUGUI weightTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fishWeight;

        weightTextComponent = GetComponent<TextMeshProUGUI>();
        fishWeight = FishDetails.fishWeight;

        weightTextComponent.text = fishWeight.ToString("0.00") + " kg";
    }
}
