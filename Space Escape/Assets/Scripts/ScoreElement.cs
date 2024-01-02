using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreElement : MonoBehaviour
{
    public TMP_Text rankText;
    public TMP_Text usernameText;
    public TMP_Text timeText;

    public void NewScoreElement(int _rank, string _username, string _time)
    {
        rankText.text = _rank.ToString();
        usernameText.text = _username;
        timeText.text = _time.ToString();
    }
}
