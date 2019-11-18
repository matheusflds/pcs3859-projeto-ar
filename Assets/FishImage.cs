using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishImage : MonoBehaviour
{
    private Image fishImageComponent;

    public Sprite salmonImage;
    public Sprite tunaImage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string fishName;

        fishImageComponent = GetComponent<Image>();
        fishName = FishDetails.fishName;

        if (fishName == "tuna")
        {
            fishImageComponent.sprite = tunaImage;
        }
        else
        {
            fishImageComponent.sprite = salmonImage;
        }
    }
}
