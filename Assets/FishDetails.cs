using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishDetails : MonoBehaviour
{
    public static string fishName;
    public static float fishWeight;

    // Start is called before the first frame update
    void Start()
    {
        string[] fishNames = new string[] { "salmon", "tuna" };
        float[,] fishWeightRanges = new float[,] { { 26.0f, 34.0f }, { 120.0f, 300.0f } };
        int fishNumber;

        fishNumber = Random.Range(0, fishNames.Length);

        fishName = fishNames[fishNumber];
        fishWeight = Random.Range(fishWeightRanges[fishNumber, 0], fishWeightRanges[fishNumber, 1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene("GameScene");
        }
    }

    public void Clear()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameScene");
    }
}
