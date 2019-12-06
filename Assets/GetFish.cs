using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFish : MonoBehaviour
{
    private CountDown timer;
    private bool counting;
    public GameObject fishManager;
    public Material standardMat;
    public Material nearFishMat;
    public Material capturingFishMat;
    // Start is called before the first frame update
    void Start()
    {
        fishManager = GameObject.Find("FishManager");
        Material mat = this.standardMat;
        if (mat != null) {
            this.SetMaterial(mat);
        }
        CountDown countdown = gameObject.AddComponent(typeof(CountDown)) as CountDown;
        this.timer = countdown;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fishManager.transform.childCount; i++)
        {
            GameObject child = fishManager.transform.GetChild(i).gameObject;
            float distance = Vector3.Distance(child.transform.position, this.transform.position);
            // Debug.Log("Distance: " + distance);
            if (distance <= 1.5f) {
                Handheld.Vibrate();
                this.SetMaterial(this.capturingFishMat);
                if (!this.counting) {
                    this.timer.Start(4);
                    this.counting = true;
                } else if(this.timer.timeLeft == 0) {
                    SceneManager.LoadScene("FishCaughtScene");
                    this.counting = false;
                }
            } else {
                this.SetMaterial(this.standardMat);
                this.counting = false;
            }
        }
    }

    private void SetMaterial(Material mat) {
        GameObject ropeContainer = GameObject.Find("FishingIndicator");
        Renderer r = ropeContainer.GetComponent<Renderer>();
        r.material = mat;
    }
}
