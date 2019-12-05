using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TunaImageScript : MonoBehaviour
{
    private Image tunaImage;

    // Start is called before the first frame update
    void Start()
    {
        tunaImage = GetComponent<Image>();
        tunaImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool fishImage = TunaCatalogScript.fishImage;
        tunaImage.enabled = fishImage;

    }
}
