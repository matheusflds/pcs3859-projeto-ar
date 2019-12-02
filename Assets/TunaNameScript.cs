using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TunaNameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool fishImage = TunaCatalogScript.fishImage;

        TextMeshProUGUI fishNameComponent = GetComponent<TextMeshProUGUI>();

        if (fishImage == true)
        {
            fishNameComponent.text = "Atum";
        }
    }
}
