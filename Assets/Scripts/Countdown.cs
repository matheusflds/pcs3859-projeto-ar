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

    private void Start()
    {
    
    }
    //public void Start(int duration)
    //{
    //    this.timeLeft = duration;
    //    StartCoroutine("LoseTime");
    //    Time.timeScale = 1; //Just making sure that the timeScale is right
    //}

    public void Begin(int duration)
    {
        this.timeLeft = duration;
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

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