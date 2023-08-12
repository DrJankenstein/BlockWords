using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;
    private float currentTime;
    public Text timerText;
    public ScoreManager scoreManager;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Timer has reached 0, perform any necessary actions
            // or stop the timer if needed
            currentTime = 0;
            // Example: Call a method when the timer reaches 0
            TimerCompleted();
        }
    }

    void UpdateTimerText()
    {
        // Round up the current time to the nearest second
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();
    }


    void TimerCompleted()
    {
        int score = scoreManager.score;
        GameManager.instance.GameOver(score);
    }
}
