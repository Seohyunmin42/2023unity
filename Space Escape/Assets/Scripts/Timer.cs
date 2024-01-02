using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;

    public string finishTime;
    private AuthManager authManager;
    private Dictionary<TimerFormats, string> timerformats = new Dictionary<TimerFormats, string>();
    // Start is called before the first frame update
    void Start()
    {
        timerformats.Add(TimerFormats.Whole, "0");
        timerformats.Add(TimerFormats.TenthDecimal, "0.0");
        timerformats.Add(TimerFormats.HundrethsDecimal, "0.00");
        authManager = FindObjectOfType<AuthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            timerText.text = "Failed";
            enabled = false;
        }
        else
        {
            SetTimerText();
        }
    }

    public void StopTimer()
    {
        int minutes2 = Mathf.FloorToInt(currentTime / 60);
        int seconds2 = Mathf.FloorToInt(currentTime % 60);
        SetTimerText();
        timerText.color = Color.blue;
        timerText.text = string.Format("{0:00}:{1:00}", minutes2, seconds2);
        finishTime = string.Format("{0:00}:{1:00}", minutes2, seconds2);
        Debug.Log("ing");
        if(authManager != null)
        {
            authManager.finishGame(finishTime);
            Debug.Log("recv info");
        }
        enabled = false;
    }
    private void SetTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(minutes == 0)
        {
            timerText.text = hasFormat ? currentTime.ToString(timerformats[format]) : currentTime.ToString();
        }
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}