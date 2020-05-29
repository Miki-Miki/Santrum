using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class TimeMaster : MonoBehaviour
{
    [Header("Timer")]
    public float timer;

    [HideInInspector]
    public float startingTime;
    private float nextLevelTime;

    [HideInInspector]
    public int numberOfResets = 0;

    private Text timerText;

    [HideInInspector]
    public bool isStarted;

    [HideInInspector]
    public bool isTimerActivated;

    void Start()
    {
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        startingTime = timer;        
        timerText.text = convertTime(startingTime);
    }

    void Update()
    {
        if(isStarted) {
            timer -= Time.deltaTime;
            timerText.text = convertTime(timer);
        }
    }

    private string convertTime(float time) {
        float secTotal = time;
        int min;
        float sec;
        string timerTime;

        if(secTotal >= 60) {
            min = (int)secTotal / 60;
            sec = secTotal - (60 * min);
            timerTime = Mathf.Round(min) + ":" + Math.Round(sec, 2);
        } else if (secTotal < 60 && secTotal >= 0) {
            timerTime = "0:" + Math.Round(secTotal, 2);
        } else {
            timerTime = "0:00.00";
        }

        return timerTime;
    }

    public bool isTimeOver() { return (float)Mathf.Abs(timer) <= 0.01f; }
    
    public void RestartTimer(float newTime = 0) { 
        if(newTime != 0) {
            nextLevelTime = newTime;
            startingTime = newTime;
        }
        
        if(nextLevelTime == 0) {
            timer = startingTime;
        } else {
            timer = nextLevelTime;
        }

        numberOfResets = 0; 
    }
    
    public void CutTimeInHalf() { 
        //Debug.Log("Number of resets: " + numberOfResets);
        if(numberOfResets > 0) {
            timer = startingTime / (2 * numberOfResets); 
        } else {
            timer = startingTime / 2;
        }
    }

    public void IncrementNumOfResets() { numberOfResets += 1; }
    public void AddTime(float additionalTime) { timer += additionalTime; }

}
