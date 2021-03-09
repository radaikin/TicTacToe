﻿using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    private bool timerIsRunning;
    private Text timerText;
    private Font font;


    void Start()
    {
        time = 0f;
        timerIsRunning = true;

        font = Resources.Load<Font>("Fonts/Love Craft");
        timerText = gameObject.GetComponent<Text>();
        timerText.font = font;
        GameManager.GetInstance().m_RestartTimerEvent += RestartTimer;
        GameManager.GetInstance().m_StopTimer += StopTimer;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            time += Time.deltaTime;
        }
        DisplayTimer(time);
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    private void RestartTimer()
    {
        time = 0f;
    }

    public void DisplayTimer(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}