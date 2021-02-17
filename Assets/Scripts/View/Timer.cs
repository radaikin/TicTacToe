using UnityEngine;
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

    public void ResetTimer()
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
