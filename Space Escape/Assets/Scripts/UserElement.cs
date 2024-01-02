using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserElement : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text useremailText;

    public void emailElement(string _username, string _useremail)
    {
        usernameText.text = _username;
        useremailText.text = _useremail.ToString();
    }
}
