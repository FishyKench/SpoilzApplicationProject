using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private bool isRunning = false;

    public void StartTimer()
    {
        timer = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public string GetTimeFormatted()
    {
        int minutes = (int)(timer / 60f);
        int seconds = (int)(timer % 60f);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private void Update()
    {
        if (!isRunning) return;

        timer = timer + Time.deltaTime;
        timerText.text = GetTimeFormatted();
    }
}