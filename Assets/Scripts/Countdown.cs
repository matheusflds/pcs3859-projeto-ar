using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour
{
    private int duration = 4;
    public int timeLeft; //Seconds Overall
    public Text countdown; //UI Text Object
    public void Start()
    {
        this.timeLeft = this.duration;
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    // public void Begin() {
    //     StartCoroutine("LoseTime");
    //     Time.timeScale = 1;
    // }
    // void Update()
    // {
    //     Debug.Log(timeLeft);
    //     // countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
    // }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}