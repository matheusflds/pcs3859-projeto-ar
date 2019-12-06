using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFish : MonoBehaviour
{
    public Canvas alertTextCanvas;
    private CountDown timer;
    private CountDown timer2;
    private bool onDelayAfterTry = false;
    private bool counting = false;
    private bool capturing = false;
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
        CountDown countdown2 = gameObject.AddComponent(typeof(CountDown)) as CountDown;
        this.timer2 = countdown2;
        this.alertTextCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (onDelayAfterTry)
        {
            if (timer2.timeLeft <= 0)
            {
                onDelayAfterTry = false;
            } 
            else
            {
                return;
            }
        }

        for (int i = 0; i < fishManager.transform.childCount; i++)
        {
            GameObject child = fishManager.transform.GetChild(i).gameObject;
            float distance = Vector3.Distance(child.transform.position, this.transform.position);
            if (distance <= 1.5f) {
                if (!capturing) {
                    capturing = true;
                }
            }
        }

        if (capturing)
        {

            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && timer.timeLeft > 0)
            {
                SceneManager.LoadScene("FishCaughtScene");
            }

            if (!counting)
            {
                counting = true;
                Handheld.Vibrate();
                timer.Begin(3);
                SetMaterial(capturingFishMat);
                alertTextCanvas.enabled = true;
                UpdateFishMovement(false);
            }
            else if (timer.timeLeft <= 0)
            {
                SetMaterial(standardMat);
                counting = false;
                capturing = false;
                alertTextCanvas.enabled = false;
                UpdateFishMovement(true);
                onDelayAfterTry = true;
                timer2.Begin(5);
            }

        }
    }

    private void SetMaterial(Material mat) 
    {
        GameObject ropeContainer = GameObject.Find("FishingIndicator");
        Renderer r = ropeContainer.GetComponent<Renderer>();
        r.material = mat;
    }

    private void UpdateFishMovement(bool enableMovement)
    {
        for (int i = 0; i < fishManager.transform.childCount; i++)
        {
            GameObject child = fishManager.transform.GetChild(i).gameObject;
            Flock childFlock = child.GetComponent<Flock>();
            childFlock.enableMovement = enableMovement;
        }
    }
   
}
