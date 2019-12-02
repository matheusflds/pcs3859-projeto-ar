using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalmonImageScript : MonoBehaviour
{
    private Image fishImageImage;

    // Start is called before the first frame update
    void Start()
    {
        fishImageImage = GetComponent<Image>();
        fishImageImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool fishImage = SalmonCatalogScript.fishImage;
        fishImageImage.enabled = fishImage;

    }
}
