using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFish : MonoBehaviour
{
    private CountDown timer;
    private bool counting;
    private bool capturing;
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
                if (!this.counting) {
                    this.capturing = true;
                }
            }
        }


        if (this.capturing)
        {
            if (!this.counting)
            {
                this.counting = true;
                Handheld.Vibrate();
                this.timer.Start(4);
                this.SetMaterial(this.capturingFishMat); 
            }
            else if (this.timer.timeLeft == 0)
            {
                this.SetMaterial(this.standardMat);
                this.counting = false;
                this.capturing = false;
                SceneManager.LoadScene("FishCaughtScene");
            }
            
        }
    }

    private void SetMaterial(Material mat) {
        GameObject ropeContainer = GameObject.Find("FishingIndicator");
        Renderer r = ropeContainer.GetComponent<Renderer>();
        r.material = mat;
    }
}
