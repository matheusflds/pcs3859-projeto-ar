using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalmonNameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fishImage = SalmonCatalogScript.fishImage;

        TextMeshProUGUI fishNameComponent = GetComponent<TextMeshProUGUI>();

        if(fishImage == true)
        {
            fishNameComponent.text = "Salmão";
        }
    }
}
