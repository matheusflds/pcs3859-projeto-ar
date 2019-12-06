using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalmonCatalogScript : MonoBehaviour
{
    public static bool fishImage;
    public static string maxWeight;
    public static string minWeight;

    // Start is called before the first frame update
    void Start()
    {
        int fishLength = PlayerPrefs.GetInt("salmonTotalLength");
        float[] allFish = new float[fishLength];

        for(int i = 0; i < fishLength; i++)
        {
            allFish[i] = PlayerPrefs.GetFloat("salmon" + i);
        }

        if (fishLength > 0)
        {
            fishImage = true;
            maxWeight = allFish.Max().ToString("0.00") + " kg";
            minWeight = allFish.Min().ToString("0.00") + " kg";
        }
        else
        {
            fishImage = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
