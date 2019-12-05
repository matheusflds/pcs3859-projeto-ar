using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFish : MonoBehaviour
{
    public GameObject fishManager;
    public Material standardMat;
    public Material nearFishMat;
    public Material capturingFishMat;
    // Start is called before the first frame update
    void Start()
    {
        fishManager = GameObject.Find("FishManager");
        // Material mat = this.standardMat;
        // if (mat != null) {
        //     this.SetMaterial(mat);
        // }
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
                // this.SetMaterial(this.capturingFishMat);
                // SceneManager.LoadScene("FishCaughtScene");
            }
        }
    }

    private void SetMaterial(Material mat) {
        GameObject ropeContainer = GameObject.Find("RopeContainer");
        int childCount = ropeContainer.transform.childCount;
        for (int i = 0; i < childCount; i++) {
            GameObject ropeParts = ropeContainer.transform.GetChild(i).gameObject;
            Renderer r = ropeParts.GetComponent<Renderer>();
            r.material = mat;
        }

        // Renderer rend = GetComponent<Renderer>();
        // if (rend != null) {
        //     rend.material = mat;
        // }
    }
}
